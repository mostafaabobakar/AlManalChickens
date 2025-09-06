using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Domain.ViewModel.PartnersSuccess
{
    public class CreatePartnerSuccess
    {
        [Required (ErrorMessage ="هذا الحقل مطلوب")]
        public IFormFile Image { get; set; }
        public string Name { get; set; }
    }
}
