using AlManalChickens.Domain.Common.Helpers.Validation;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Services.Api.Contract.General;
using FluentValidation;
using System.ComponentModel;

namespace AlManalChickens.Services.DTO.AuthApiDTO
{
    public class ChangePasswordDto
    {
        [DisplayName("رقم الجوال")] public string Phone { get; set; }
        [DisplayName("كلمة المرور القديمة")] public string OldPassword { get; set; }
        [DisplayName("كلمة المرور الجديدة")] public string NewPassword { get; set; }
    }

    public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordDtoValidator(IUserContext userContext)
        {
            var lang = userContext.APILang;
            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang,
                    DefaultPath.ValidationLocalizationPath, nameof(x.Phone), ValidationTypesEnum.Required))
                .Matches(RegEx.SaudiPhone)
                .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang,
                    DefaultPath.ValidationLocalizationPath, nameof(x.Phone), ValidationTypesEnum.SaudiPhone));

            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang,
                    DefaultPath.ValidationLocalizationPath, nameof(x.OldPassword), ValidationTypesEnum.Required))
                .MinimumLength(6)
                .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang,
                    DefaultPath.ValidationLocalizationPath, nameof(x.OldPassword), ValidationTypesEnum.MinLength, 6));
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang,
                    DefaultPath.ValidationLocalizationPath, nameof(x.NewPassword), ValidationTypesEnum.Required))
                .MinimumLength(6)
                .WithMessage(x => FluentValidationHelper.Message<ChangePasswordDto>(lang,
                    DefaultPath.ValidationLocalizationPath, nameof(x.NewPassword), ValidationTypesEnum.MinLength, 6));
        }
    }
}