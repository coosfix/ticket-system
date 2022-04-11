using Microsoft.AspNetCore.Mvc;
namespace Ticket_System.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IUserManageService userManageService;

        public AdminController(IUserManageService userManageService)
        {
            this.userManageService = userManageService;
        }
        public IActionResult Index()
        {
            return View(userManageService.GetUsers());
        }
        public IActionResult Add()
        {
            TempData["RoleItems"] = userManageService.GetRoleItems();
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (userManageService.Add(model))
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            TempData["RoleItems"] = userManageService.GetRoleItems();
            return View(userManageService.GetSingle(id));
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (userManageService.Edit(model))
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (userManageService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
