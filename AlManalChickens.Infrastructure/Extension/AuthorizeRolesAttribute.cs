namespace AlManalChickens.Infrastructure.Extension
{
    public class AuthorizeRolesAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params AlManalChickens.Domain.Enums.Roles[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}
