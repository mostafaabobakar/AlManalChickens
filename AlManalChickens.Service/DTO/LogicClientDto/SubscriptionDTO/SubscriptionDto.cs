using AlManalChickens.Services.DTO.LogicClientDto.PackageDto;

namespace AlManalChickens.Services.DTO.LogicClientDto.SubscriptionDTO
{
    public class SubscriptionDto
    {
        public string PackageName { get; set; }
        public string startDate { get; set; }
        public bool IsFreePackage { get; set; }
        public string EndDate { get; set; }
        public List<PackageListDto> Packages { get; set; }
    }
}
