using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.ViewModel.Slider
{
    public class CreateSliderViewModel
    {
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string SliderName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Url { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime ExpireDate { get; set; }

    }
}
