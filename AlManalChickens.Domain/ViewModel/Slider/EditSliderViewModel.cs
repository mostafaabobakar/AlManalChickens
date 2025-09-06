using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.ViewModel.Slider
{
    public class EditSliderViewModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        //public string SliderName { get; set; }
        public string CurrentImage { get; set; }
        public IFormFile NewImage { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string? Url { get; set; }
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime? ExpireDate { get; set; }
    }
}
