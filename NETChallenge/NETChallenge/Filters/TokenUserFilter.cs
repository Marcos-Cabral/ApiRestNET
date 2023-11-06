using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace challenge.Filters
{
    public class TokenUserFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userIdClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                context.HttpContext.Items["UserId"] = userIdClaim.Value;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}