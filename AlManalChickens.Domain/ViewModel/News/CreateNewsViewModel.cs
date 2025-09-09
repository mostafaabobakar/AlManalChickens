using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Domain.ViewModel.News
{
    public class CreateNewsViewModel
    {
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string Title { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Text { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public IFormFile Image { get; set; }
    }
}
