using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.ViewModel.Question
{
    public class CreateQuestionViewModel
    {
        [Required(ErrorMessage="هذا الحقل مطلوب")]
        public string QuestionAr { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AnswerAr { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string QuestionEn { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AnswerEn { get; set; }

    }
}
