﻿using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Enums;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Services.DTO.AppClientDTO.ContactUsClientDto
{
    public class ContactUsClientAddDto
    {
        [Required]
        public string userName { get; set; }
        /// <summary>
        /// email or phone
        /// </summary>
        [Required]
        public string email { get; set; }
        [Required]
        public string msg { get; set; }
        public string lang { get; set; } = "ar";
    }
    public class ContactUsDtoValidator : AbstractValidator<ContactUsClientAddDto>
    {
        public ContactUsDtoValidator(IStringLocalizer<ContactUsClientAddDto> localizer)
        {

            RuleFor(x => x.userName).NotEmpty()
                           .WithMessage(e => AAITHelper.HelperMsg.creatMessage(e.lang, Helper.getFileTranslate(Lang.Translate.ar, "userName"), Helper.getFileTranslate(Lang.Translate.en, "userName")));


            RuleFor(x => x.email).NotEmpty().WithMessage(e => AAITHelper.HelperMsg.creatMessage(e.lang, Helper.getFileTranslate(Lang.Translate.ar, "email"), Helper.getFileTranslate(Lang.Translate.en, "email")))
                             .EmailAddress()
                           .WithMessage(e => AAITHelper.HelperMsg.creatMessage(e.lang, Helper.getFileTranslate(Lang.Translate.ar, "emailAddress"), Helper.getFileTranslate(Lang.Translate.en, "emailAddress")));


            RuleFor(x => x.msg).NotEmpty()
                            .WithMessage(e => AAITHelper.HelperMsg.creatMessage(e.lang, Helper.getFileTranslate(Lang.Translate.ar, "msg"), Helper.getFileTranslate(Lang.Translate.en, "msg")));


        }

    }
}
