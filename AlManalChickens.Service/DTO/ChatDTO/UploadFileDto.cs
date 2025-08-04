using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.DTO.ChatDTO
{
    public class UploadFileDto
    {
        public IFormFile File { get; set; }
    }
}
