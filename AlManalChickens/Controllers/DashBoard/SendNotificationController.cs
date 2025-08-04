using AlManalChickens.Domain.Enums;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Services.DashBoard.Contract.NotificationInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRoles(Roles.Admin, Roles.Notifications)]
    public class SendNotificationController : Controller
    {
        private readonly INotificationServices _notificationServices;

        public SendNotificationController(INotificationServices notificationServices = null)
        {
            _notificationServices = notificationServices;
        }

        public async Task<IActionResult> Index()
        {
            var UserNotifies = await _notificationServices.GetHistoryNotify();

            return View(UserNotifies);

        }

        public IActionResult SendNotify()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _notificationServices.GetUsers();

            return Ok(new { key = 1, users });
        }
    

        [HttpPost]
        public async Task<IActionResult> Send(string msg, string employees)
        {
            await _notificationServices.Send(msg, employees);

            return Ok(new { redirectToUrl = Url.Action("Index", "SendNotification") });
        }
    }
}