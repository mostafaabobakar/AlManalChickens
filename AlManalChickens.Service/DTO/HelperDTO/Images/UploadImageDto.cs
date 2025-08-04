using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.DTO.HelperDTO.Images
{
    public class UploadImageDto
    {
        public IFormFile image { get; set; }
        public int fileName { get; set; }
    }
}
