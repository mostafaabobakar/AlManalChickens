using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Services.DTO.CouponDto
{
    public class UseCouponDto
    {
        [Required]
        public string couponCode { get; set; }
        public int couponId { get; set; }
        public string userId { get; set; }
        public double total { get; set; }
        [FromHeader]
        public string lang { get; set; } = "ar";

    }
}
