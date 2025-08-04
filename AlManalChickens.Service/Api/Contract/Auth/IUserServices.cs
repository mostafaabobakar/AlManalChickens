using AlManalChickens.Domain.Common.Helpers.Notifications;
using AlManalChickens.Domain.Entities.UserTables;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Services.DTO.AuthApiDTO;

namespace AlManalChickens.Services.Api.Contract.Auth
{
    public interface IUserServices
    {
        Task<(bool IsSuccess, string messageKey)> ValidateUser(string email, string phone,
            HashSet<int>? citiesId = null);

        Task<int> GenerateCode(int currentCode);
        Task<ApplicationDbUser?> AddUser(RegisterDto dto);
        Task<bool> AddUserToRole(ApplicationDbUser user, string roleName);
        Task<bool> IsDeviceExist(string deviceId);
        Task<Device?> GetUserDevice(string deviceId);
        Task<bool> AddDeviceId(DeviceDto dto, string userId);

        Task<(bool IsSuccess, ApplicationDbUser? user, string messageKey)> IsValidUser(string phone);
        Task<bool> ValidatePassword(string passwordOne, string passwordTwo);
        Task<ApplicationDbUser?> GetUserByPhone(string phoneNumber);
        Task<string> SendSms(int code, string phone);
        Task<(bool IsSuccess, string messageKey)> UpdatePassword(ApplicationDbUser user, string newPassword);
        Task<UserInfoDto> GetUserInfo(string userId, string token);
        Task<string> GetToken(string userId, UserType userType, string userName, bool autoGenerate = true);
        Task<bool> SendNotifyAsync(NotifyModel model);
    }
}