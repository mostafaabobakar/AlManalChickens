using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Domain.ViewModel.Product
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string NameEn { get; set; }
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public double Price { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public double DiscountPrice { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public double Weigth { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string DescriptionAr { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string DescriptionEn { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public int CategoryId { get; set; }
    }
}
