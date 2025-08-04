using AlManalChickens.Domain.Entities.UserTables;

namespace AlManalChickens.Domain.ViewModel.Admin
{
    public class GetUsersWithRolesViewModel
    {
        public List<ApplicationDbUser> users { get; set; }
        public List<string> roles { get; set; }
    }
}
