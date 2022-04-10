namespace Ticket_System.Models
{
    public class TicketType
    {
        public int TicketTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Role> Roles { get; set; }
        public List<TicketTypeRules> TicketRules { get; set; }
    }
}
