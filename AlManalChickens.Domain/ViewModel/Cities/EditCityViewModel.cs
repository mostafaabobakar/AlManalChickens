using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.ViewModel.Cities
{
    public class EditCityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المدينة بالعربية ")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل اسم المدينة بالانجليزية")]
        public string NameEn { get; set; }

    }
}
