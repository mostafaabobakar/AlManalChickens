using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Security.Claims;

namespace AlManalChickens.Services.Middlewares.UserConfigs
{
    public class UserConfigMiddleware
    {
        private readonly RequestDelegate _next;

        public UserConfigMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            //Get User ID on Web
            string WebUserId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            httpContext.Items["WebUserId"] = !string.IsNullOrWhiteSpace(WebUserId) ? WebUserId : "";

            //Get User ID on API
            string APIUserId = httpContext.User.Claims.FirstOrDefault(c => c.Type == "user_id")?.Value;
            httpContext.Items["APIUserId"] = !string.IsNullOrWhiteSpace(APIUserId) ? APIUserId : "";

            // Get Lang on Web
            string language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName; //<-- better and safer approach
            //string language2 = CultureInfo.CurrentCulture.Name.Substring(0, 2);
            httpContext.Items["WebLang"] = !string.IsNullOrWhiteSpace(language) ? language : "ar";

            //Get Lang on API
            httpContext.Items["APILang"] = httpContext.Request.Headers.AcceptLanguage.FirstOrDefault("ar");


            //To Catch These values in Controller
            //EX: var WebUserId = HttpContext.Items["WebUserId"] as string;
            //Ex: var WebUserId = _httpContextAccessor.HttpContext.Items["WebUserId"] as string;

            /*
             * Note HttpContext Only Accessible from BaseController or Middleware,
            if you want to access it outside them please use IHttpContextAccessor "DI"
            */

            //Push it into the Pipeline: app.UseUserConfigMiddleware();


            await _next(httpContext);
        }
    }


}
