using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Domain.ViewModel.Settings;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.SettingInterfaces;

namespace AlManalChickens.Services.DashBoard.Implementation.SettingImplementation
{
    public class SettingServices : ISettingServices
    {
        private readonly ApplicationDbContext _context;

        public SettingServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SettingEditViewModel> GetSetting(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var setting = await _context.Settings.FindAsync(id);

            SettingEditViewModel editsetting = new SettingEditViewModel
            {
                Id = setting.Id,
                CondtionsArClient = setting.CondtionsArClient,
                CondtionsEnClient = setting.CondtionsEnClient,
                CondtionsArDelegt = setting.CondtionsArProvider,
                CondtionsEnDelegt = setting.CondtionsEnProvider,
                AboutUsArClient = setting.AboutUsArClient,
                AboutUsEnClient = setting.AboutUsEnClient,
                AboutUsArDelegt = setting.AboutUsArProvider,
                AboutUsEnDelegt = setting.AboutUsEnProvider,
                ApplicationId = setting.ApplicationId,
                SenderName = setting.SenderNameSms,
                PasswordSms = setting.PasswordSms,
                Phone = setting.Phone,
                SenderId = setting.SenderId,
                UserNameSms = setting.UserNameSms,
                Email = setting.Email,
                Lat = setting.Lat,
                Lng = setting.Lng,
                Address = setting.Address
            };
            if (setting == null)
            {
                return null;
            }

            return editsetting;
        }

        public async Task<bool> EditSetting(SettingEditViewModel editSettingViewModel)
        {
            Setting setting = await _context.Settings.FindAsync(editSettingViewModel.Id);
            setting.Id = editSettingViewModel.Id;
            setting.CondtionsArClient = editSettingViewModel.CondtionsArClient;
            setting.CondtionsEnClient = editSettingViewModel.CondtionsEnClient;
            setting.CondtionsArProvider = editSettingViewModel.CondtionsArDelegt;
            setting.CondtionsEnProvider = editSettingViewModel.CondtionsEnDelegt;
            setting.AboutUsArClient = editSettingViewModel.AboutUsArClient;
            setting.AboutUsEnClient = editSettingViewModel.AboutUsEnClient;
            setting.AboutUsArProvider = editSettingViewModel.AboutUsArDelegt;
            setting.AboutUsEnProvider = editSettingViewModel.AboutUsEnDelegt;
            setting.ApplicationId = editSettingViewModel.ApplicationId;
            setting.SenderNameSms = editSettingViewModel.SenderName;
            setting.PasswordSms = editSettingViewModel.PasswordSms;
            setting.Phone = editSettingViewModel.Phone;
            setting.SenderId = editSettingViewModel.SenderId;
            setting.UserNameSms = editSettingViewModel.UserNameSms;
            setting.Email = editSettingViewModel.Email;
            setting.Lat = editSettingViewModel.Lat;
            setting.Lng = editSettingViewModel.Lng;
            setting.Address = editSettingViewModel.Address;

            return await _context.SaveChangesAsync() > 0;
        }

        public bool SettingExists(int id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}
