using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.DTO.DashbordDTO.AppDTO
{
    public class AdvertismentsEditDto
    {
        public int Id { get; set; }
        public string TitelAr { get; set; }
        public string TitelEn { get; set; }
        public string Img { get; set; }
        public IFormFile ImgFile { get; set; }
        public int Type { get; set; }
    }
}
