namespace backend.Services;
using Microsoft.AspNetCore.Mvc.Filters;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AdministratorAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (backend.Models.AuthResponse?)context.HttpContext.Items["User"];
        if (user is null) context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        if (user.role != Models.Role.administrador) context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
    }
}