using System.ComponentModel.DataAnnotations;

namespace Ticket_System.ViewModels
{
    public class TicketsViewModel
    {
        public int TicketsId { get; set; }
        [Required(ErrorMessage = "Description 為必填欄位")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Summary 為必填欄位")]
        public string Summary { get; set; }
        public string Severity { get; set; }
        public string Priority { get; set; }
        [Display(Name ="Type")]
        public int TicketsTypeId { get; set; }
        public string UserName { get; set; }
        public bool Resolved { get; set; }
    }
}
