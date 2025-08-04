using AlManalChickens.Domain.Entities.Copon;

namespace AlManalChickens.Services.DTO.CouponDto
{
    public class CopounValidationDto
    {
        public Result<string> Result { get; set; }
        public Copon Copoun { get; set; }
    }
}
