using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.DTO.UserDto
{
    public class ChangeDataRequestDto
    {
        public string? UserName { get; set; } = null;
        public string? Email { get; set; } = null;
        public IFormFile? Image { get; set; } = null;
        public string Lang { get; set; }

    }
}
