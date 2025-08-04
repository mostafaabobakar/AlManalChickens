using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.ViewModel.Regions
{
    public class CreateRegionViewModel
    {
        [Required(ErrorMessage = "من فضلك ادخل اسم الحي بالعربية ")]
        public string NameAr { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم الحي بالانجليزية")]
        public string NameEn { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "من فضلك اختر مدينتك")]
        public int CityId { get; set; }
    }
}
