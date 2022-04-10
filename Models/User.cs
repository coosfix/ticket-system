namespace Ticket_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public Role UserRole { get; set; }
        public List<Tickets> Tickets { get; set; }
    }
}
