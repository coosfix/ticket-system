using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ticket_System.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketsManageService ticketsManageService;

        public TicketController(ITicketsManageService ticketsManageService)
        {
            this.ticketsManageService = ticketsManageService;
        }
        public IActionResult Index()
        {
            return View(ticketsManageService.GetAll());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TicketsViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (ticketsManageService.Add(model))
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ticketsManageService.Delete(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            return View(ticketsManageService.GetSingle(id));
        }

        [HttpPost]
        public IActionResult Edit(TicketsViewModel model)
        {
            if (ticketsManageService.Update(model))
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }        
        [HttpPost]
        public IActionResult Resolve(int id)
        {
            if (ticketsManageService.Resolve(id))
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
