using Microsoft.AspNetCore.Mvc.Filters;

namespace Ticket_System.Filters
{
    public class IgonreGlobalFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
