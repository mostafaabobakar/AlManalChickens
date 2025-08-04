using AlManalChickens.Domain.ViewModel.Users;

namespace AlManalChickens.Services.DashBoard.Contract.UserInterfaces
{
    public interface IUserServices
    {
        Task<List<UsersViewModel>> GetUsers();
        Task<bool> ChangeState(string UserId);
    }
}
