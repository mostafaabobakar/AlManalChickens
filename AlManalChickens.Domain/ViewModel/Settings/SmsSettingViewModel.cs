﻿using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.ViewModel.Settings
{
    public class SmsSettingViewModel
    {
        public string SmsProvider { get; set; }
        public string SenderName { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string UserNameSms { get; set; }
        [Required(ErrorMessage = "من فضلك هذا الحقل مطلوب")]
        public string PasswordSms { get; set; }
    }
}
