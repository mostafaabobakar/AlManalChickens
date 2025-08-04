using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.DTO.DashbordDTO.AppDTO
{
    public class AdvertismentsAddDto
    {
        public string TitelAr { get; set; }
        public string TitelEn { get; set; }
        public int Type { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
