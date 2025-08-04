using AlManalChickens.Services.DashBoard.Contract.HomeInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.DashBoard
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly IHomeServices _homeServices;

        public HomeController(IHomeServices homeServices = null)
        {
            _homeServices = homeServices;
        }

        public IActionResult Index()
        {
            var data =_homeServices.HomeIndex();

            return View(data);
        }
    }
}
