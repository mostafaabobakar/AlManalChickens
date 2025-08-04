using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Admin;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Services.DashBoard.Contract.AdminInterfaces;
using Microsoft.AspNetCore.Mvc;


namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRoles(Roles.Admin)]

    public class AdminController : Controller
    {


        private readonly IAdminServices _adminServices;

        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }


        public IActionResult UserInRoles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRoles([FromBody] UserRolesViewModel obj)
        {
            if (obj.users.Length == 0)
                return Json(new { key = 2, msg = "يجب تحديد مستخدم" });

            await _adminServices.EditUsersInRoles(obj);

            return Json(new { key = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var result=await _adminServices.GetUsersWithRoles();
            return Json(new { users = result.users, roles = result.roles });
        }

        [HttpPost]
        public async Task<IActionResult> EditUserRoles([FromBody] UserIdViewModel userId)
        {
            var UserRoles=await _adminServices.EditUserRoles(userId);
            return Json(new { user= UserRoles.user, userRoles = UserRoles.userRoles });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _adminServices.ListRoles();
            if (roles.Count() > 0)
            {
                return Json(new { key = 1, roles });
            }
            else
            {
                return Json(new { key = 0, msg = "لايوجد صلاحيات .." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAlluser()
        {
            var users = await _adminServices.ListUsers();

            if (users.Count() > 0)
            {
                return Json(new { key = 1, users = users });
            }
            else
            {
                return Json(new { key = 0, msg = "لايوجد مستخدمين .." });
            }
        }

    }
}
