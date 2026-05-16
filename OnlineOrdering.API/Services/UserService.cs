using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using System.Security.Cryptography;
using System.Text;

namespace OnlineOrdering.API.Services;

public class UserService
{
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

        return new LoginResponse { Success = true, Message = "登录成功", User = MapToDto(user) };
    }

    public async Task<LoginResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _db.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);

        if (existingUser != null)
        {
            return new LoginResponse { Success = false, Message = "用户名已存在" };
        }

        var user = new User
        {
            Username = request.Username,
            PasswordHash = HashPassword(request.Password),
            Role = "Customer",
            RealName = request.RealName,
            Phone = request.Phone,
            Address = request.Address,
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

        if (request.RealName != null) user.RealName = request.RealName;
        if (request.Phone != null) user.Phone = request.Phone;
        if (request.Address != null) user.Address = request.Address;
        if (request.IsActive.HasValue) user.IsActive = request.IsActive.Value;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangePasswordAsync(int id, ChangePasswordRequest request)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null || user.IsDeleted) return false;

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

        user.PasswordHash = HashPassword(newPassword);
        await _db.SaveChangesAsync();
        return true;
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "OrderingSystemSalt"));
        return Convert.ToBase64String(bytes);
    }

    private static bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
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
