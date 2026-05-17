using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Security;

public static class ClientRequestContext
{
    public const string RoleHeader = "X-Client-Role";
    public const string UserIdHeader = "X-User-Id";

    public static string GetRole(HttpContext httpContext)
    {
        return httpContext.Request.Headers[RoleHeader].FirstOrDefault()?.Trim() ?? string.Empty;
    }

    public static int? GetUserId(HttpContext httpContext)
    {
        return int.TryParse(httpContext.Request.Headers[UserIdHeader].FirstOrDefault(), out var userId)
            ? userId
            : null;
    }

    public static bool IsAdmin(HttpContext httpContext)
    {
        var role = GetRole(httpContext);
        return string.Equals(role, UserRoles.Admin, StringComparison.OrdinalIgnoreCase)
            || string.Equals(role, UserRoles.SuperAdmin, StringComparison.OrdinalIgnoreCase);
    }
}
