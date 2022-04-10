using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ticket_System.Services.Interface
{
    public interface ITicketsManageService
    {

        public List<TicketsViewModel> GetAll();
        public bool Add(TicketsViewModel model);
        public bool Update(TicketsViewModel model);
        public bool Delete(int id);
        public bool Resolve(int id);
        public List<SelectListItem> TicketTypeItems(int roleId);
        public TicketsViewModel GetSingle(int id);
    }
}
