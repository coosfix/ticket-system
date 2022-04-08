using Microsoft.AspNetCore.Mvc;

namespace Ticket_System.Controllers
{
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
            if (loginManageService.IsLoggedIn(model))
            {
                HttpContext.Session.SetString(nameof(model.UserName), model.UserName.StringToBase64());
                HttpContext.Session.SetString(nameof(model.Password), model.Password.StringToBase64());
                return RedirectToAction("Index", "Home");
            }

            TempData["LoginError"] = "登入帳號密碼錯誤!!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
