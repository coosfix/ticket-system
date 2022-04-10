namespace Ticket_System.Services.Interface
{
    public interface IAccessManageService
    {
        bool TicketDel(int role, int type);
        bool TicketEdit(int role, int type);
        bool TicketAdd(int role);
        bool TicketResolved(int role, int type);
    }
}
