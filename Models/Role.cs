namespace Ticket_System.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public ICollection<TicketType> TicketTypes { get; set; }
        public List<TicketTypeRules> TicketRules { get; set; }        
        public ICollection<TicketAction> TicketActions { get; set; }
        public List<TicketActionRules> TicketActionRules { get; set; }
    }
}
