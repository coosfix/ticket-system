using Ticket_System.Models;

namespace Ticket_System.Services.Implement
{
    public class LoginManageService : ILoginManageService
    {
        private readonly TicketDBContext dBContext;

        public LoginManageService(TicketDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool IsLoggedIn(LoginViewModel model)
        {
            var user = dBContext.Users
                .Where(w => w.Name == model.UserName && w.Password == model.Password)
                .FirstOrDefault();


            return user != null;
        }
    }
}
