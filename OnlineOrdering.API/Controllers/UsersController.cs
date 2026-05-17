using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;
using OnlineOrdering.API.Security;
using OnlineOrdering.API.Services;

namespace OnlineOrdering.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"获取用户列表失败：{ex.Message}" });
        }
    }

    [HttpGet("{id}")]
    [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"获取用户详情失败：{ex.Message}" });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        try
        {
            var result = await _userService.RegisterAsync(request);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"用户注册失败：{ex.Message}" });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var result = await _userService.LoginAsync(request);
            if (!result.Success) return BadRequest(new { message = result.Message });
            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"用户登录失败：{ex.Message}" });
        }
    }

    [HttpPut("{id}")]
    [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
    public IActionResult Update(int id, [FromBody] UpdateUserRequest request)
    {
        return BadRequest(new { message = "后台不允许修改用户个人资料，请仅使用账号状态管理接口。" });
    }

    [HttpPut("{id}/status")]
    [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateUserStatusRequest request)
    {
        try
        {
            var success = await _userService.UpdateUserStatusAsync(id, request.IsActive);
            if (!success) return NotFound();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"更新账号状态失败：{ex.Message}" });
        }
    }

    [HttpPost("{id}/change-password")]
    [RequireClientRole(UserRoles.Customer, UserRoles.Admin, UserRoles.SuperAdmin)]
    public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordRequest request)
    {
        try
        {
            if (!ClientRequestContext.IsAdmin(HttpContext) && ClientRequestContext.GetUserId(HttpContext) != id)
            {
                return StatusCode(403, new { message = "不能修改其他用户的密码。" });
            }

            var success = await _userService.ChangePasswordAsync(id, request);
            if (!success) return BadRequest("密码修改失败，请检查原密码是否正确");
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"修改密码失败：{ex.Message}" });
        }
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePasswordByUsername([FromBody] ChangePasswordByUsernameRequest request)
    {
        try
        {
            var success = await _userService.ChangePasswordByUsernameAsync(request);
            if (!success) return BadRequest(new { message = "用户名或原密码不正确" });
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"修改密码失败：{ex.Message}" });
        }
    }

    [HttpPost("{id}/reset-password")]
    [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
    public IActionResult ResetPassword(int id, [FromBody] ResetPasswordRequest request)
    {
        return BadRequest(new { message = "后台不提供重置密码，请使用顾客端的忘记密码功能。" });
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
    {
        try
        {
            var success = await _userService.ForgotPasswordAsync(request);
            if (!success) return BadRequest(new { message = "用户名或真实姓名不匹配" });
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"找回密码失败：{ex.Message}" });
        }
    }

    [HttpDelete("{id}")]
    [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
    public IActionResult Delete(int id)
    {
        return BadRequest(new { message = "后台不允许删除用户账号，只能启用或停用。" });
    }
}

public class ResetPasswordRequest
{
    public string NewPassword { get; set; } = "123456";
}
