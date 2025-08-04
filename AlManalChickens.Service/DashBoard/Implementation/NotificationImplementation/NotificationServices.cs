using AAITHelper;
using AAITHelper.ModelHelper;
using AlManalChickens.Domain.Common.Helpers.Notifications;
using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Domain.Entities.UserTables;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Notification;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.NotificationInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Services.DashBoard.Implementation.NotificationImplementation
{
    public class NotificationServices : INotificationServices
    {
        private readonly ApplicationDbContext _context;

        public NotificationServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HistoryNotificationViewModel>> GetHistoryNotify()
        {
            var UserNotifies = await _context.HistoryNotify
                .Select(x => new HistoryNotificationViewModel
                {
                    Text = x.Text,
                    TextDate = x.Date,
                    UserNotifyCount = x.UserCountNotify,
                    ProviderNotifyCount = x.ProviderCountNotify,
                }).ToListAsync();
            return UserNotifies;
        }

        public async Task<List<UsersViewModel>> GetUsers()
        {
            var users = await _context.Users.Where(u => u.IsActive && u.Type == UserType.Client && u.AllowNotify)
                .Select(x => new UsersViewModel
                {
                    id = x.Id,
                    name = x.FullName
                }).ToListAsync();
            return users;
        }

        public async Task<bool> Send(string msg, string users)
        {
            List<Notification> NotifyUsers = [];

            if (users != null)
            {
                var usersArr = users.Split(',');
                foreach (var clientId in usersArr)
                {
                    NotifyUsers.Add(new Notification
                    {
                        UserId = clientId,
                        TextAr = msg,
                        TextEn = msg,
                        Type = NotifyType.NotifyFromDashboard
                    });

                    await SendFCMToMutipleUsers(msg, usersArr, (int)NotifyType.NotifyFromDashboard);
                }

                await _context.Notifications.AddRangeAsync(NotifyUsers);
            }

            await _context.HistoryNotify.AddAsync(new HistoryNotify
            {
                Text = msg,
                Date = HelperDate.GetCurrentDate(),
                UserCountNotify = NotifyUsers.Count
            });

            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<bool> SendFCMToMutipleUsers(string msg, string[] deviceIds, int notifyType)
        {

            var AllDeviceIds = await _context.Devices
                       .AsNoTracking()
                       .Where(x => deviceIds.Contains(x.UserId))
                       .Select(x => new DeviceIdModel
                       {
                           DeviceId = x.Identifier,
                           DeviceType = x.DeviceType,
                           FkUser = x.UserId,
                           ProjectName = x.ProjectName
                       })
                       .ToListAsync();

            var data = new Dictionary<string, string>()
            {
                {"type", $"{notifyType}"},
            };

            await FCMHelper.SendPushNotificationAsync(AllDeviceIds, data, msg);
            return true;
        }
    }
}