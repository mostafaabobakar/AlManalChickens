using AlManalChickens.Domain.ViewModel.Settings;

namespace AlManalChickens.Services.DashBoard.Contract.SettingInterfaces
{
    public interface ISettingServices
    {
        Task<SettingEditViewModel> GetSetting(int? id);
        Task<bool> EditSetting(SettingEditViewModel settingEditViewModel);
        bool SettingExists(int id);
    }
}
