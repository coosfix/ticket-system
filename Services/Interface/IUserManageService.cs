using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ticket_System.Services.Interface
{
    public interface IUserManageService
    {
        List<UserViewModel> GetUsers();
        bool Add(UserViewModel model);
        bool Edit(UserViewModel model);
        bool Delete(int id);
        UserViewModel GetSingle(int id);
        List<SelectListItem> GetRoleItems();
    }
}
