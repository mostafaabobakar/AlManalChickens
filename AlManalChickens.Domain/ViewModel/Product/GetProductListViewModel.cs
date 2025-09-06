using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Domain.ViewModel.Product
{
    public class GetProductListViewModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double Weigth { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
