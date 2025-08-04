using AlManalChickens.Domain.ViewModel.Notification;

namespace AlManalChickens.Services.DashBoard.Contract.NotificationInterfaces
{
    public interface INotificationServices
    {
        Task<List<HistoryNotificationViewModel>> GetHistoryNotify();
        Task<List<UsersViewModel>> GetUsers();
        Task<bool> Send(string msg, string users);
    }
}
