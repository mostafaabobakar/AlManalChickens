using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Services.DTO.DashbordDTO.AuthDTO
{
    public class AdminEditDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public string Img { get; set; }
        public IFormFile FileImage { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
