using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ticket_System.Services.Implement
{
    public class UserManageService : IUserManageService
    {
        private readonly TicketDBContext ticketDBContext;

        public UserManageService(TicketDBContext ticketDBContext)
        {
            this.ticketDBContext = ticketDBContext;
        }
        public bool Add(UserViewModel model)
        {
            try
            {
                ticketDBContext.User.Add(new User
                {
                    Name = model.Name,
                    Password = model.Password,
                    UserRoleId = model.RoleId
                });
                ticketDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var target = ticketDBContext.User.Find(id);
                if (target is null) return false;
                ticketDBContext.User.Remove(target);
                ticketDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(UserViewModel model)
        {
            try
            {
                var target = ticketDBContext.User.Find(model.Id);
                if (target is null) return false;
                target.Name = model.Name;
                target.UserRoleId = model.RoleId;
                ticketDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SelectListItem> GetRoleItems()
        {
            return ticketDBContext.Role
                .AsNoTracking()
                .Select(s => new SelectListItem { Text = s.Name, Value = s.RoleId.ToString() })
                .ToList();
        }

        public UserViewModel GetSingle(int id)
        {
            var data = ticketDBContext.User.Find(id);
            return new UserViewModel { Id = data.Id, Name = data.Name, RoleId = data.Id };
        }

        public List<UserViewModel> GetUsers()
        {
            return ticketDBContext.User
                .AsNoTracking()
                .Select(s => new UserViewModel { Id = s.Id, Name = s.Name, RoleId = s.UserRoleId })
                .ToList();
        }
    }
}
