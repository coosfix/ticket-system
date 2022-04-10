using Microsoft.AspNetCore.Mvc;
using Ticket_System.Filters;

namespace Ticket_System.Controllers
{
    [TypeFilter(typeof(IgonreGlobalFilter))]
    public class LoginController : Controller
    {
        private readonly ILoginManageService loginManageService;

        public LoginController(ILoginManageService loginManageService)
        {
            this.loginManageService = loginManageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //驗證登入帳密
            if (loginManageService.IsLoggedIn(model, out int? userId, out int? role))
            {
                HttpContext.Session.SetInt32(nameof(role), role.Value);
                HttpContext.Session.SetInt32(nameof(userId), userId.Value);
                HttpContext.Session.SetString(nameof(model.UserName), model.UserName);
                return RedirectToAction("Index", "Ticket");
            }

            TempData["LoginError"] = "登入帳號密碼錯誤!!";
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(LoginViewModel model)
        {

            //TempData["LoginError"] = "註冊帳號密碼錯誤!!";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
