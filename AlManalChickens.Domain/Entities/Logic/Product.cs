using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Domain.Entities.Logic
{
    public class Product: BaseEntity
    {
        public string  Image { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double  Weigth{ get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category  Category  { get; set; }
    }
}
