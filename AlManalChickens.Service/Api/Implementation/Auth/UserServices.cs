using AAITHelper;
using AAITHelper.ModelHelper;
using AutoMapper.QueryableExtensions;
using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Common.Helpers.Notifications;
using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Domain.Entities.UserTables;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Persistence;
using AlManalChickens.Services.Api.Contract.Auth;
using AlManalChickens.Services.DTO.AuthApiDTO;
using AlManalChickens.Services.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using NotifyModel = AlManalChickens.Domain.Common.Helpers.Notifications.NotifyModel;

namespace AlManalChickens.Services.Api.Implementation.Auth
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationDbUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IConfiguration _configuration;
        private readonly IHelper _helper;

        public UserServices(ApplicationDbContext context, UserManager<ApplicationDbUser> userManager,
            ICurrentUserService currentUserService, IConfiguration configuration, IHelper uploadImage = null)
        {
            _context = context;
            _userManager = userManager;
            _currentUserService = currentUserService;
            _configuration = configuration;
            _helper = uploadImage;
        }

        public async Task<(bool IsSuccess, string messageKey)> ValidateUser(string email, string phone,
            HashSet<int>? citiesId)
        {
            /*if (citiesId.Count == 0)
                return (false, "ChooseAtLeastOneCity");*/
            if (await IsExistEmail(email))
                return (false, "ThisEmailIsAlreadyExists");
            if (await IsExistPhone(phone))
                return (false, "ThisMobileAlreadyExists");
            if (citiesId is { Count: > 0 })
            {
                if (!await IsValidCities(citiesId))
                    return (false, "OneOrMoreCityNotValid");
            }

            return (true, string.Empty);
        }

        public async Task<ApplicationDbUser?> AddUser(RegisterDto dto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = new ApplicationDbUser
                {
                    FullName = dto.UserName,
                    UserName = dto.Phone + Helper.GetRandomNumber() + "@yahoo.com",
                    Email = dto.Email,
                    Code = await GenerateCode(1234),
                    Type = UserType.Client,
                    PhoneNumber = dto.Phone,
                    ProfilePicture = dto.Image is not null
                        ? _helper.Upload(dto.Image, (int)FileName.Users)
                        : string.Empty,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                var result = await _userManager.CreateAsync(user, dto.Password);

                if (result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return user;
                }

                await transaction.RollbackAsync();
                return null;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return null;
            }
        }

        public async Task<bool> AddUserToRole(ApplicationDbUser user, string roleName)
        {
            var result = (await _userManager.AddToRoleAsync(user, roleName)).Succeeded;
            return result;
        }


        public async Task<bool> IsDeviceExist(string deviceId) => await _context.Devices
            .AnyAsync(x => x.Identifier == deviceId && x.UserId == _currentUserService.UserId);

        public async Task<Device?> GetUserDevice(string deviceId)
        {
            return await _context.Devices.FirstOrDefaultAsync(x =>
                x.Identifier == deviceId && x.UserId == _currentUserService.UserId);
        }


        public async Task<int> GenerateCode(int currentCode)
        {
            try
            {
                int code = HelperNumber.GetRandomNumber(currentCode); // return 123456
                Setting GetInfoSms = await _context.Settings.FirstOrDefaultAsync();
                if (GetInfoSms != null)
                {
                    if (GetInfoSms.SenderNameSms != "test")
                    {
                        code = Helper.GetRandomNumber();
                    }
                }

                return code;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> AddDeviceId(DeviceDto dto, string userId)
        {
            try
            {
                Device deviceId = new()
                {
                    Identifier = dto.DeviceId,
                    DeviceType = dto.DeviceType,
                    UserId = userId,
                    ProjectName = dto.ProjectName
                };
                await _context.Devices.AddAsync(deviceId);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<ApplicationDbUser?> GetUserByPhone(string phoneNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<bool> ValidatePassword(string passwordOne, string passwordTwo)
        {
            return passwordOne == passwordTwo;
        }


        public async Task<(bool IsSuccess, ApplicationDbUser? user, string messageKey)> IsValidUser(string phone)
        {
            var user = await GetUserByPhone(phone);
            if (user is null)
                return (false, null, "UserNotFound");
            if (!user.IsActive)
                return (false, null, "UserIsNotActive");
            return (true, user, string.Empty);
        }

        public async Task<string> SendSms(int code, string phone)
        {
            var getInfoSms = await _context.Settings.FirstOrDefaultAsync();
            if (getInfoSms != null)
            {
                if (getInfoSms.SenderNameSms != "test")
                {
                    string resultSms = await HelperSms.SendMessageBy4jawaly(code.ToString(), phone,
                        getInfoSms.SenderNameSms, getInfoSms.SenderNameSms, getInfoSms.SenderNameSms);
                    return resultSms;
                }
            }

            return "";
        }

        public async Task<(bool IsSuccess, string messageKey)> UpdatePassword(ApplicationDbUser user, string newPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
                return (false, "ErrorChangingPassword");

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return (true, "PasswordResetedSuccessfully");
        }

        public async Task<UserInfoDto> GetUserInfo(string userId, string token)
        {
            var userInfoDto = await _context.Users
                .Where(x => x.Id == userId && x.Type == UserType.Client)
                .AsQueryable()
                .AsNoTracking()
                .ProjectTo<UserInfoDto>(MappingProfiles.UserInfo(token))
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return userInfoDto;
        }


        public async Task<string> GetToken(string userId, UserType userType, string userName, bool autoGenerate = true)
        {
            try
            {
                var token = HelperGeneral.GetToken(_configuration, userId, userType.ToString(), userName);
                return autoGenerate ? new JwtSecurityTokenHandler().WriteToken(token) : "";
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> SendNotifyAsync(NotifyModel model)
        {
            try
            {
                var user = await _context.Users
                    .Include(x => x.Devices)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == model.UserId);

                if (user is null)
                    return false;

                if (user!.AllowNotify || model.Type == NotifyType.RemoveUser || model.Type == NotifyType.BlockUser)
                {
                    await AddNotification(model);

                    var userDevices = user.Devices
                        .Select(x => new DeviceIdModel
                        {
                            DeviceId = x.Identifier,
                            DeviceType = x.DeviceType,
                            FkUser = x.UserId,
                            ProjectName = x.ProjectName
                        }).ToList();

                    var data = new Dictionary<string, string>
                    {
                        {"itemId", $"{model.ItemId }" },
                        {"type", $"{(int)model.Type}" },
                        {"userType", $"{user.Type}" },
                        {"userId", $"{model.UserId}" },
                    };

                    await FCMHelper.SendPushNotificationAsync(userDevices, data, HelperMsg.creatMessage(user.Lang, model.TextAr, model.TextEn));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #region Private Methods
        private async Task<bool> IsExistEmail(string email, string? userId = null) =>
            await _userManager.Users.AnyAsync(x => x.Email == email && (userId == null || x.Id != userId));

        private async Task<bool> IsExistPhone(string phone, string? userId = null) =>
            await _userManager.Users.AnyAsync(x => x.PhoneNumber == phone && (userId == null || x.Id != userId));

        private async Task<bool> IsValidCities(HashSet<int>? citiesId)
        {
            foreach (var cityId in citiesId)
            {
                var city = await _context.Cities.FindAsync(cityId);
                if (city is null)
                    return false;
            }
            return true;
        }

        private async Task<bool> AddNotification(NotifyModel model)
        {
            await _context.Notifications.AddAsync(new Notification
            {
                TextAr = model.TextAr,
                TextEn = model.TextEn,
                Type = model.Type,
                UserId = model.UserId,
                ItemId = model.ItemId
            });

            return await _context.SaveChangesAsync() > 0;
        }
        #endregion
    }
}