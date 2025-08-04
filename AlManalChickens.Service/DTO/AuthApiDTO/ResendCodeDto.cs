using AlManalChickens.Domain.Common.Helpers.Validation;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Services.Api.Contract.General;
using FluentValidation;
using System.ComponentModel;


namespace AlManalChickens.Services.DTO.AuthApiDTO;

public class ResendCodeDto
{
    [DisplayName("رقم الجوال")] public string PhoneNumber { get; set; }
}

public class ResendCodeDtoValidator : AbstractValidator<ResendCodeDto>
{
    public ResendCodeDtoValidator(IUserContext userContext)
    {
        var lang = userContext.APILang;
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(x => FluentValidationHelper.Message<ResendCodeDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.PhoneNumber), ValidationTypesEnum.Required))
            .Matches(RegEx.SaudiPhone)
            .WithMessage(x => FluentValidationHelper.Message<ResendCodeDto>(lang, DefaultPath.ValidationLocalizationPath,
                nameof(x.PhoneNumber), ValidationTypesEnum.SaudiPhone));
    }
}