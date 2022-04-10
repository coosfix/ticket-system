namespace Ticket_System.Services.Interface
{
    public interface ILoginManageService
    {
        bool IsLoggedIn(LoginViewModel model, out int? UserId, out int? RoleName);
    }
}
