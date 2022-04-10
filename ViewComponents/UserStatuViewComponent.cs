using Microsoft.AspNetCore.Mvc;

namespace Ticket_System.ViewComponents
{
    public class UserStatuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
