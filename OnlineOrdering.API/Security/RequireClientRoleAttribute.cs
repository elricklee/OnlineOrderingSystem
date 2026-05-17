using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OnlineOrdering.API.Security;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public sealed class RequireClientRoleAttribute : Attribute, IAsyncActionFilter
{
    private readonly HashSet<string> _allowedRoles;

    public RequireClientRoleAttribute(params string[] allowedRoles)
    {
        _allowedRoles = new HashSet<string>(allowedRoles ?? Array.Empty<string>(), StringComparer.OrdinalIgnoreCase);
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var role = ClientRequestContext.GetRole(context.HttpContext);
        if (string.IsNullOrWhiteSpace(role) || !_allowedRoles.Contains(role))
        {
            context.Result = new ObjectResult(new { message = "当前客户端无权访问该接口。" })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
            return;
        }

        await next();
    }
}
