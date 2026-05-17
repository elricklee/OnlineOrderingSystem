using Microsoft.AspNetCore.Mvc;
using OnlineOrdering.API.Models;
using OnlineOrdering.API.Security;
using OnlineOrdering.API.Services;

namespace OnlineOrdering.API.Controllers;

[ApiController]
[Route("api/dishcategories")]
public class DishCategoriesController : ControllerBase
{
    private readonly IDishCategoryService _service;

    public DishCategoriesController(IDishCategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    [RequireClientRole(UserRoles.Admin, UserRoles.SuperAdmin)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _service.GetAllAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"获取菜品分类失败：{ex.Message}" });
        }
    }

    [HttpGet("enabled")]
    public async Task<IActionResult> GetEnabled()
    {
        try
        {
            return Ok(await _service.GetAllAsync(enabledOnly: true));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = $"获取启用分类失败：{ex.Message}" });
        }
    }
}
