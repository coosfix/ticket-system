namespace Ticket_System.Models
{
    public class Tickets
    {
        public int TicketsId { get; set; }
        public string Description { get; set; }
        public string Summary{ get; set; }
        public string Severity{ get; set; }
        public string Priority{ get; set; }
        public bool Resolved { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
