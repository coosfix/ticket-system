namespace Ticket_System.Services.Implement
{
    public class AccessManageService : IAccessManageService
    {
        private readonly TicketDBContext ticketDBContext;

        public AccessManageService(TicketDBContext ticketDBContext)
        {
            this.ticketDBContext = ticketDBContext;
        }
        public bool TicketAdd(int role)
        {
            return ticketDBContext.TicketActionRules
                .Where(w => w.RoleId == role)
                .Any(a => a.TicketAction.ActionName == nameof(ActionEnum.Add));
        }

        public bool TicketDel(int role, int type)
        {
            return ticketDBContext.TicketActionRules
                .Where(w => w.RoleId == role && w.TicketAction.TicketTypeId == type)
                .Any(a => a.TicketAction.ActionName == nameof(ActionEnum.Delete));
        }

        public bool TicketEdit(int role, int type)
        {
            return ticketDBContext.TicketActionRules
                .Where(w => w.RoleId == role && w.TicketAction.TicketTypeId == type)
                .Any(a => a.TicketAction.ActionName == nameof(ActionEnum.Edit));
        }

        public bool TicketResolved(int role, int type)
        {
            return ticketDBContext.TicketActionRules
                .Where(w => w.RoleId == role && w.TicketAction.TicketTypeId == type)
                .Any(a => a.TicketAction.ActionName == nameof(ActionEnum.Resolve));
        }
    }
}
