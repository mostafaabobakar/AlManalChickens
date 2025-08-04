using AlManalChickens.Domain.Entities.UserTables;
using Microsoft.AspNetCore.Identity;

namespace AlManalChickens.Domain.ViewModel.Admin
{
    public class UserWithRolesViewModel
    {
        public List<IdentityRole> userRoles { get; set; }
        public ApplicationDbUser user { get; set; }

    }
}
