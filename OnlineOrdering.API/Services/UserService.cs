using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlineOrdering.API.Services;

public class UserService
{
    private static readonly Regex PhoneRegex = new("^1[3-9]\\d{9}$", RegexOptions.Compiled);
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _db.Users
            .Where(u => !u.IsDeleted)
            .OrderByDescending(u => u.CreatedAt)
            .ToListAsync();

        return users.Select(MapToDto).ToList();
    }

    public async Task<UserDto?> GetUserByIdAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);
        return user == null || user.IsDeleted ? null : MapToDto(user);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _db.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username && !u.IsDeleted);

        if (user == null)
        {
            return new LoginResponse { Success = false, Message = "用户不存在" };
        }

        if (!user.IsActive)
        {
            return new LoginResponse { Success = false, Message = "账号已被禁用" };
        }

        if (!VerifyPassword(request.Password, user.PasswordHash))
        {
            return new LoginResponse { Success = false, Message = "密码错误" };
        }

        if (NeedsPasswordUpgrade(user.PasswordHash))
        {
            user.PasswordHash = HashPassword(request.Password);
            await _db.SaveChangesAsync();
        }

        return new LoginResponse { Success = true, Message = "登录成功", User = MapToDto(user) };
    }

    public async Task<LoginResponse> RegisterAsync(RegisterRequest request)
    {
        var username = request.Username.Trim();
        var realName = request.RealName?.Trim();
        var phone = request.Phone?.Trim();
        var address = request.Address?.Trim();

        if (string.IsNullOrWhiteSpace(username))
        {
            return new LoginResponse { Success = false, Message = "用户名不能为空" };
        }

        if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
        {
            return new LoginResponse { Success = false, Message = "密码长度至少6个字符" };
        }

        if (string.IsNullOrWhiteSpace(realName))
        {
            return new LoginResponse { Success = false, Message = "真实姓名不能为空" };
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            return new LoginResponse { Success = false, Message = "手机号不能为空" };
        }

        if (!PhoneRegex.IsMatch(phone))
        {
            return new LoginResponse { Success = false, Message = "手机号格式不正确" };
        }

        if (string.IsNullOrWhiteSpace(address))
        {
            return new LoginResponse { Success = false, Message = "常用地址不能为空" };
        }

        var matchedZone = await FindMatchingDeliveryZoneAsync(address);
        if (matchedZone == null)
        {
            return new LoginResponse { Success = false, Message = "常用地址必须位于已开通的配送区域内" };
        }

        var existingUser = await _db.Users
            .FirstOrDefaultAsync(u => u.Username == username);

        if (existingUser != null)
        {
            return new LoginResponse { Success = false, Message = "用户名已存在" };
        }

        var user = new User
        {
            Username = username,
            PasswordHash = HashPassword(request.Password),
            Role = UserRoles.Customer,
            RealName = realName,
            Phone = phone,
            Address = NormalizeAddress(address, matchedZone),
            CreatedAt = DateTime.Now,
            IsActive = true
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return new LoginResponse { Success = true, Message = "注册成功", User = MapToDto(user) };
    }

    public async Task<bool> UpdateUserAsync(int id, UpdateUserRequest request)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null || user.IsDeleted) return false;

        if (request.IsActive.HasValue) user.IsActive = request.IsActive.Value;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateUserStatusAsync(int id, bool isActive)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null || user.IsDeleted) return false;

        user.IsActive = isActive;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangePasswordAsync(int id, ChangePasswordRequest request)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null || user.IsDeleted) return false;

        ValidatePassword(request.NewPassword);

        if (!VerifyPassword(request.OldPassword, user.PasswordHash))
        {
            return false;
        }

        user.PasswordHash = HashPassword(request.NewPassword);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangePasswordByUsernameAsync(ChangePasswordByUsernameRequest request)
    {
        var username = request.Username.Trim();
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username && !u.IsDeleted);
        if (user == null) return false;

        ValidatePassword(request.NewPassword);

        if (!VerifyPassword(request.OldPassword, user.PasswordHash))
        {
            return false;
        }

        user.PasswordHash = HashPassword(request.NewPassword);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null) return false;

        user.IsDeleted = true;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ResetPasswordAsync(int id, string newPassword)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null || user.IsDeleted) return false;

        ValidatePassword(newPassword);
        user.PasswordHash = HashPassword(newPassword);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request)
    {
        var username = request.Username.Trim();
        var realName = request.RealName.Trim();
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username && !u.IsDeleted);
        if (user == null)
        {
            return false;
        }

        if (!string.Equals(user.RealName?.Trim(), realName, StringComparison.Ordinal))
        {
            return false;
        }

        ValidatePassword(request.NewPassword);
        user.PasswordHash = HashPassword(request.NewPassword);
        await _db.SaveChangesAsync();
        return true;
    }

    private async Task<DeliveryZone?> FindMatchingDeliveryZoneAsync(string address)
    {
        var normalizedAddress = NormalizeWhitespace(address);
        var zones = await _db.DeliveryZones
            .Where(zone => zone.IsActive)
            .OrderByDescending(zone => (zone.Province + zone.City + zone.District).Length)
            .ToListAsync();

        return zones.FirstOrDefault(zone => GetZonePrefixes(zone).Any(prefix =>
            normalizedAddress.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)));
    }

    private static string NormalizeAddress(string address, DeliveryZone zone)
    {
        var normalizedAddress = NormalizeWhitespace(address);
        var detail = normalizedAddress;

        foreach (var prefix in GetZonePrefixes(zone))
        {
            if (normalizedAddress.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                detail = normalizedAddress[prefix.Length..].Trim();
                break;
            }
        }

        return string.Join(
            " ",
            new[] { zone.Province.Trim(), zone.City.Trim(), zone.District.Trim(), detail }
                .Where(value => !string.IsNullOrWhiteSpace(value)));
    }

    private static IEnumerable<string> GetZonePrefixes(DeliveryZone zone)
    {
        yield return NormalizeWhitespace($"{zone.Province} {zone.City} {zone.District}");
        yield return NormalizeWhitespace($"{zone.Province}{zone.City}{zone.District}");
        yield return NormalizeWhitespace($"{zone.Province} / {zone.City} / {zone.District}");
    }

    private static string NormalizeWhitespace(string value)
    {
        return Regex.Replace(value, "\\s+", " ").Trim();
    }

    private static void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
        {
            throw new InvalidOperationException("新密码长度至少6个字符");
        }
    }

    private static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        const int iterations = 100_000;
        var hashBytes = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, 32);
        return $"PBKDF2${iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hashBytes)}";
    }

    private static bool VerifyPassword(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
        {
            return false;
        }

        if (!hash.StartsWith("PBKDF2$", StringComparison.Ordinal))
        {
            return VerifyLegacyPassword(password, hash);
        }

        var parts = hash.Split('$');
        if (parts.Length != 4 || !int.TryParse(parts[1], out var iterations))
        {
            return false;
        }

        try
        {
            var salt = Convert.FromBase64String(parts[2]);
            var expectedHash = Convert.FromBase64String(parts[3]);
            var actualHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, expectedHash.Length);
            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
        catch
        {
            return false;
        }
    }

    private static bool VerifyLegacyPassword(string password, string hash)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "OrderingSystemSalt"));
        return Convert.ToBase64String(bytes) == hash;
    }

    private static bool NeedsPasswordUpgrade(string hash)
    {
        return !hash.StartsWith("PBKDF2$", StringComparison.Ordinal);
    }

    private static UserDto MapToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Role = user.Role,
            RealName = user.RealName,
            Phone = user.Phone,
            Address = user.Address,
            CreatedAt = user.CreatedAt,
            IsActive = user.IsActive
        };
    }
}
