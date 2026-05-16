using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.DTOs;
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
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await _userService.RegisterAsync(request);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _userService.LoginAsync(request);
        if (!result.Success) return Unauthorized(result);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
    {
        var success = await _userService.UpdateUserAsync(id, request);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpPost("{id}/change-password")]
    public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordRequest request)
    {
        var success = await _userService.ChangePasswordAsync(id, request);
        if (!success) return BadRequest("密码修改失败，请检查原密码是否正确");
        return Ok();
    }

    [HttpPost("{id}/reset-password")]
    public async Task<IActionResult> ResetPassword(int id, [FromBody] ResetPasswordRequest request)
    {
        var success = await _userService.ResetPasswordAsync(id, request.NewPassword);
        if (!success) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _userService.DeleteUserAsync(id);
        if (!success) return NotFound();
        return Ok();
    }
}

public class ResetPasswordRequest
{
    public string NewPassword { get; set; } = "123456";
}
