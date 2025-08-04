using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.DTO.DashbordDTO.AppApiDTO
{
    public class AdvertismentsEditApiDto
    {
        public int Id { get; set; }
        public string TitelAr { get; set; }
        public string TitelEn { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
