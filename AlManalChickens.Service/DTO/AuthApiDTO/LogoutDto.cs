using AlManalChickens.Domain.Common.Helpers.Validation;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Services.Api.Contract.General;
using FluentValidation;

namespace AlManalChickens.Services.DTO.AuthApiDTO;

public class LogoutDto
{
    public string DeviceId { get; set; }
}

public class LogoutDtoValidator : AbstractValidator<LogoutDto>
{
    public LogoutDtoValidator(IUserContext userContext)
    {
        var lang = userContext.APILang;
        RuleFor(x => x.DeviceId)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<LogoutDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.DeviceId), ValidationTypesEnum.Required));
    }
}