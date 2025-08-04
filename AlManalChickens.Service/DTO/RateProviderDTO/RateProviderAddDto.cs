namespace AlManalChickens.Services.DTO.RateProviderDTO
{
    public class RateProviderAddDto
    {
        public string userId { get; set; }
        public string providerId { get; set; }
        public string userName { get; set; }
        public int rate { get; set; }
        public string lang { get; set; } = "ar";
    }
}
