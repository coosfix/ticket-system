using System.ComponentModel.DataAnnotations;

namespace Ticket_System.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="使用者姓名欄位必填")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "使用者密碼欄位必填")]
        public string Password { get; set; }
    }
}
