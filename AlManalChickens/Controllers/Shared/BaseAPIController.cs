using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.Shared
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [ValidationFilter]
    public class BaseAPIController : ControllerBase
    {
        protected string Lang
        {
            get
            {
                return HttpContext?.Items["APILang"] as string ?? string.Empty;
            }
        }

        protected string UserId
        {
            get
            {
                return HttpContext?.Items["APIUserId"] as string ?? string.Empty;
            }
        }

    }
}
