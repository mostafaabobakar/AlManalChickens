using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Services.DTO.More
{
    public class ContactWithUsDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        [FromHeader]
        public string lang { get; set; } = "ar";
    }
}
