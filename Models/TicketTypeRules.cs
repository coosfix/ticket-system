using Microsoft.EntityFrameworkCore;

namespace Ticket_System.Models
{
    public class TicketTypeRules
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
