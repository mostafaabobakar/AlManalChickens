using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Domain.ViewModel.PartnersSuccess
{
    public class GetPartnersSuccessById
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string  Name{ get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
