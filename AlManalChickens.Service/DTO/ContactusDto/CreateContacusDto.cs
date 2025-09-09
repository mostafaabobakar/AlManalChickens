using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DTO.ContactusDto
{
    public class CreateContacusDto
    {
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        public string userName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string message { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string email { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string region { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public int gender { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public int contactusType { get; set; }

    }
}
