using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Domain.ViewModel.News
{
    public class GetNewsByIdViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public bool IsActive { get; set; }
    }
}
