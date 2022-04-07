namespace Ticket_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public UserGroup Group { get; set; }
    }
}
