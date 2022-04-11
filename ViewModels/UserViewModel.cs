using System.ComponentModel.DataAnnotations;

namespace Ticket_System.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="欄位必填")]
        public string Name { get; set; }
        [Required(ErrorMessage = "欄位必填")]
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
