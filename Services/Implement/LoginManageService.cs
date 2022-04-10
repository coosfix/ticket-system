using Microsoft.EntityFrameworkCore;

namespace Ticket_System.Services.Implement
{
    public class LoginManageService : ILoginManageService
    {
        private readonly TicketDBContext dBContext;

        public LoginManageService(TicketDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public bool IsLoggedIn(LoginViewModel model, out int? UserId, out int? RoleName)
        {
            var user = dBContext.User.Include(p=>p.UserRole)
                .Where(w => w.Name == model.UserName && w.Password == model.Password)
                .FirstOrDefault();
            UserId = user?.Id;
            RoleName = user?.UserRoleId;
            return user != null;
        }
    }
}
