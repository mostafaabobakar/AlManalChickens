using AlManalChickens.Domain.Entities.UserTables;
using AlManalChickens.Domain.ViewModel.Admin;

namespace AlManalChickens.Services.DashBoard.Contract.AdminInterfaces
{
    public interface IAdminServices
    {
        Task<bool> EditUsersInRoles(UserRolesViewModel obj);
        Task<GetUsersWithRolesViewModel> GetUsersWithRoles();
        Task<List<ApplicationDbUser>> ListUsers();
        Task<List<RolesViewModel>> ListRoles();
        Task<UserWithRolesViewModel> EditUserRoles(UserIdViewModel userId);
    }
}
