using AlManalChickens.Services.Api.Contract.General;
using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.Api.Implementation.General
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string WebUserId => _httpContextAccessor.HttpContext?.Items["WebUserId"] as string ?? "";

        public string WebLang => _httpContextAccessor.HttpContext?.Items["WebLang"] as string ?? "";

        public string APIUserId => _httpContextAccessor.HttpContext?.Items["APIUserId"] as string ?? "";

        public string APILang => _httpContextAccessor.HttpContext?.Items["APILang"] as string ?? "";
    }
}
