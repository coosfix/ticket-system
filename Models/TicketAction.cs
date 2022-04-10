using System.ComponentModel.DataAnnotations;

namespace Ticket_System.Models
{
    public class TicketAction
    {
        [Key]
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
        public ICollection<Role> Roles { get; set; }
        public List<TicketActionRules> TicketActionRules { get; set; }

    }
}
