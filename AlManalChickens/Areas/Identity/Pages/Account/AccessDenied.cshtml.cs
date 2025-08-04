using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlManalChickens.Areas.Identity.Pages.Account
{
    public class AccessDeniedModel : PageModel
    {
        public void OnGet()
        {
            RedirectToPage("Login");
        }
    }
}

