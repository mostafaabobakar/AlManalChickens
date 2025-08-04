using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Settings;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Services.DashBoard.Contract.SettingInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRoles(Roles.Admin, Roles.Setting)]
    public class SettingsController : Controller
    {
        private readonly ISettingServices _settingServices;

        public SettingsController(ISettingServices settingServices)
        {
            _settingServices = settingServices;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var editsetting = await _settingServices.GetSetting(id);

            if (editsetting == null)
            {
                return NotFound();
            }
            return View(editsetting);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SettingEditViewModel editSettingViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _settingServices.EditSetting(editSettingViewModel);
                }
                catch (Exception ex)
                {
                    if (! _settingServices.SettingExists(editSettingViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View(editSettingViewModel);
        }

    }
}