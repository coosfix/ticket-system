using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ticket_System.Filters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IAccessManageService adminManageService;

        public CustomAuthorizationFilter(IAccessManageService adminManageService)
        {
            this.adminManageService = adminManageService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var ignore = context.ActionDescriptor.FilterDescriptors
            .Select(f => f.Filter)
            .OfType<TypeFilterAttribute>()
            .Any(f => f.ImplementationType.Equals(typeof(IgonreGlobalFilter)));

            if (ignore) return;

            var UserName = context.HttpContext.Session.GetString("UserName");
            var userId = context.HttpContext.Session.GetInt32("userId");

            if (string.IsNullOrWhiteSpace(UserName) || userId == null)
            {
                context.Result = new RedirectResult("/Login/Index");
            }



        }
    }
}
