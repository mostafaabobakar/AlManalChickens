using AlManalChickens.Domain.Common.Helpers.Validation;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Services.Api.Contract.General;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace AlManalChickens.Services.DTO.AuthApiDTO;

public class RegisterDto
{
    [DisplayName("اسم المستخدم")] public string UserName { get; set; }

    [DisplayName("البريد الالكتروني")] public string Email { get; set; }

    [DisplayName("رقم الجوال")] public string Phone { get; set; }

    [DisplayName("الصورة")] public IFormFile? Image { get; set; }

    [DisplayName("الاحداثي السيني")] public string Lat { get; set; }

    [DisplayName("الاحداثي الصادي")] public string Lng { get; set; }

    [DisplayName("الموقع")] public string Location { get; set; }

    [DisplayName("كلمة المرور")] public string Password { get; set; }

    [DisplayName("الجهاز")] public DeviceDto Device { get; set; }
    //[DisplayName("المدن")] public HashSet<int> Cities { get; set; } = new HashSet<int>();
}

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator(IUserContext userContext)
    {
        var lang = userContext.APILang;

        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.UserName), ValidationTypesEnum.Required));

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Email), ValidationTypesEnum.Required))
            .Matches(RegEx.Email)
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Email), ValidationTypesEnum.Email));

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Phone), ValidationTypesEnum.Required))
            .Matches(RegEx.SaudiPhone)
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Phone), ValidationTypesEnum.SaudiPhone));

        RuleFor(x => x.Image)
            .NotNull()
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Image), ValidationTypesEnum.Required));

        RuleFor(x => x.Lat)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Lat), ValidationTypesEnum.Required));

        RuleFor(x => x.Lng)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Lng), ValidationTypesEnum.Required));

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Location), ValidationTypesEnum.Required));

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Password), ValidationTypesEnum.Required))
            .MinimumLength(6)
            .WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Password), ValidationTypesEnum.MinLength, 6));
        /*
        RuleFor(x => x.Cities)
            .Must(x => x.Count >= 1).WithMessage(x => FluentValidationHelper.Message<RegisterDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.Cities), ValidationTypesEnum.Required));
    */
    }
}