using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.ViewModel.Settings
{
    public class SettingEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [MinLength(10, ErrorMessage = "ادخل رقم الهاتف صحيح ولا يقل عن 10 أرقام")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsArClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsEnClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsArDelegt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsEnDelegt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsArClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsEnClient { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsArDelegt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsEnDelegt { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string SenderName { get; set; } = "test";
        public string UserNameSms { get; set; } = "test";
        public string PasswordSms { get; set; } = "test";
        public string ApplicationId { get; set; }
        public string SenderId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Email { get; set; }

        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Address { get; set; }

    }
}
