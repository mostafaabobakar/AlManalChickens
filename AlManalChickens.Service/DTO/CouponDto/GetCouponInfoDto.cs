namespace AlManalChickens.Services.DTO.CouponDto
{
    public class GetCouponInfoDto
    {
        public bool CouponActive { get; set; }
        public bool UserCouponRelation { get; set; }
        public bool CouponExpiry { get; set; }
        public bool CouponMaxUsage { get; set; }
        public int CouponLastTotal { get; set; }

    }
}
