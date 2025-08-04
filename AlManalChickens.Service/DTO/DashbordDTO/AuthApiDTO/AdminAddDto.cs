using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.DTO.DashbordDTO.AuthApiDTO
{
    public class AdminAddApiDto
    {
        //public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; } = null;
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
