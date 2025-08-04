using AlManalChickens.Domain.Enums;
using AlManalChickens.Persistence;
using AlManalChickens.Services.Api.Contract.Auth;
using AlManalChickens.Services.Api.Contract.General;
using AlManalChickens.Services.DTO;
using AlManalChickens.Services.DTO.AuthApiDTO;

namespace AlManalChickens.Services.Api.Implementation.Auth;

public class AccountService : IAccountService
{
    private readonly IUserServices _userService;
    private readonly ApplicationDbContext _context;
    private readonly IUserContext _userContext;

    public AccountService(IUserServices userService, ApplicationDbContext context, IUserContext userContext)
    {
        _userService = userService;
        _context = context;
        _userContext = userContext;
    }


    public async Task<Result<bool>> Register(RegisterDto dto)
    {
        var userResult = await _userService.ValidateUser(dto.Email, dto.Phone);
        if (!userResult.IsSuccess)
            return Result<bool>.Fail(userResult.messageKey);

        var user = await _userService.AddUser(dto);
        if (user is not null)
        {
            var isAddedRole = await _userService.AddUserToRole(user, Roles.Mobile.ToString());
            if (!isAddedRole)
                return Result<bool>.Fail("UserRoleAssigningError");
            var isAddedDevice = await _userService.AddDeviceId(dto.Device, user.Id);
            if (!isAddedDevice)
                return Result<bool>.Fail("DeviceAddingError");
            _ = await _userService.SendSms(user.Code, user.PhoneNumber);
            return Result<bool>.Success(true, "UserCreatedSuccessfully");
        }

        return Result<bool>.Fail("UserCreationError");
    }

    public async Task<Result<bool>> ConfirmCode(ConfirmCodeDto dto)
    {
        var userResult = await _userService.IsValidUser(dto.PhoneNumber);

        if (!userResult.IsSuccess)
            return Result<bool>.Fail(userResult.messageKey);

        if (userResult.user!.Code != dto.Code)
            return Result<bool>.Fail("Invalid Verification Code");

        userResult.user.IsCodeActivated = true;
        _context.Users.Update(userResult.user);
        await _context.SaveChangesAsync();

        return Result<bool>.Success(true, "OTPIsValid");
    }

    public async Task<Result<bool>> ResendCode(ResendCodeDto dto)
    {
        var userResult = await _userService.IsValidUser(dto.PhoneNumber);
        if (!userResult.IsSuccess)
            return Result<bool>.Fail(userResult.messageKey);
        var otp = await _userService.GenerateCode(123456);
        userResult.user.Code = otp;
        userResult.user.IsCodeActivated = false;
        _context.Users.Update(userResult.user);
        var result = await _context.SaveChangesAsync() > 0;
        await _userService.SendSms(otp, dto.PhoneNumber);
        return Result<bool>.Success(result, "CodeSentSuccessfully");
    }


    public async Task<Result<UserInfoDto>> Login(LoginDto dto)
    {
        var userResult = await _userService.IsValidUser(dto.Phone);
        if (!userResult.IsSuccess)
            return Result<UserInfoDto>.Fail(userResult.messageKey);
        //if (!userResult.user.IsCodeActivated)
        //    return Result<UserInfoDto>.Fail("ActivationCodeIsNotValidOrExpired");
        //if (!await _userService.ValidatePassword(dto.Password, userResult.user.ShowPassword))
        //    return Result<UserInfoDto>.Fail("PasswordIsNotCorrect");
        if (!await _userService.IsDeviceExist(dto.Device.DeviceId))
        {
            var isDeviceAdded = await _userService.AddDeviceId(dto.Device, userResult.user.Id);
            if (!isDeviceAdded)
                return Result<UserInfoDto>.Fail("DeviceAddingError");
        }

        var token = await _userService.GetToken(userResult.user.Id, userResult.user.Type, userResult.user.UserName);
        var userInfoResult = await _userService.GetUserInfo(userResult.user.Id, token);
        return Result<UserInfoDto>.Success(userInfoResult, "LoggedInSuccessfully");
    }

    public async Task<Result<bool>> ResetPassword(ResetPasswordDto dto)
    {
        var userResult = await _userService.IsValidUser(dto.Phone);
        if (!userResult.IsSuccess)
            return Result<bool>.Fail(userResult.messageKey);
        var result = await _userService.UpdatePassword(userResult.user, dto.NewPassword);

        return result.IsSuccess
            ? Result<bool>.Success(true, result.messageKey)
            : Result<bool>.Fail(result.messageKey);
    }

    public async Task<Result<bool>> ChangePassword(ChangePasswordDto dto)
    {
        var userResult = await _userService.IsValidUser(dto.Phone);
        if (!userResult.IsSuccess)
            return Result<bool>.Fail(userResult.messageKey);
        if (!userResult.user.IsCodeActivated)
            return Result<bool>.Fail("ActivationCodeIsNotValidOrExpired");
        //if (!await _userService.ValidatePassword(dto.OldPassword, userResult.user.ShowPassword))
        //    return Result<bool>.Fail("PasswordIsNotCorrect");

        var result = await _userService.UpdatePassword(userResult.user, dto.NewPassword);
        return result.IsSuccess
            ? Result<bool>.Success(true, result.messageKey)
            : Result<bool>.Fail(result.messageKey);
    }

    public async Task<Result<bool>> Logout(LogoutDto dto)
    {
        var user = await _context.Users.FindAsync();
        if (user is null)
            return Result<bool>.Fail("UserNotFound");
        var device = await _userService.GetUserDevice(dto.DeviceId);
        if (device is null)
            return Result<bool>.Fail("DeviceNotFound");
        user.IsCodeActivated = false;
        _context.Devices.Remove(device);
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return Result<bool>.Success(true, "LoggedOutSuccessfully");
    }

    public async Task<Result<bool>> RemoveAccount()
    {
        var user = await _context.Users.FindAsync(_userContext.APIUserId);
        if (user is null)
            return Result<bool>.Fail("UserNotFound");
        user.IsDeleted = true;
        user.PhoneNumber += Guid.NewGuid().ToString();
        user.Email += Guid.NewGuid().ToString();
        user.NormalizedEmail += Guid.NewGuid().ToString();
        user.UserName += Guid.NewGuid().ToString();
        user.NormalizedUserName += Guid.NewGuid().ToString();
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return Result<bool>.Success(true, "AccountWasRemovedSuccessfully");
    }
}