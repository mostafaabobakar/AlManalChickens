using AlManalChickens.Domain.Common.Helpers.Validation;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Services.Api.Contract.General;
using FluentValidation;
using System.ComponentModel;

namespace AlManalChickens.Services.DTO.AuthApiDTO;

public class DeviceDto
{
    [DisplayName("معرف الجهاز")] public string DeviceId { get; set; }

    [DisplayName("نظام الجهاز")] public string DeviceType { get; set; }

    [DisplayName("اسم المشروع")] public string ProjectName { get; set; }
}

public class DeviceDtoValidator : AbstractValidator<DeviceDto>
{
    public DeviceDtoValidator(IUserContext userContext)
    {
        var lang = userContext.APILang;
        RuleFor(x => x.DeviceId)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<DeviceDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.DeviceId), ValidationTypesEnum.Required));

        RuleFor(x => x.DeviceType)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<DeviceDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.DeviceType), ValidationTypesEnum.Required));

        RuleFor(x => x.ProjectName)
            .NotEmpty()
            .WithMessage(x => FluentValidationHelper.Message<DeviceDto>(lang,
                DefaultPath.ValidationLocalizationPath, nameof(x.ProjectName), ValidationTypesEnum.Required));

    }
}