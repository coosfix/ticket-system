namespace Ticket_System.Models
{
    public class TicketActionRules
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int TicketActionId { get; set; }
        public TicketAction TicketAction { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
