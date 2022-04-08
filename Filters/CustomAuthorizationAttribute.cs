using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ticket_System.Filters
{
    public class CustomAuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var UserName = context.HttpContext.Session.GetString("UserName");
            var Password = context.HttpContext.Session.GetString("Password");

            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                context.Result = new RedirectResult("Login/Index");
            }

            base.OnActionExecuting(context);
        }
    }
}
