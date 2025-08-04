using AlManalChickens.Services.DTO.CategoryDto;
using AlManalChickens.Services.DTO.ProductDto;
using AlManalChickens.Services.DTO.RegionDto;

namespace AlManalChickens.Services.DTO.HomeDto
{
    public class HomePageDto
    {
        public IReadOnlyList<CategoryListDto> CategoryListDtos { get; set; }
        public IReadOnlyList<CategoryListDto> CategoryListSideMenuDtos { get; set; }
        public IReadOnlyList<RegionListDto> RegionListDtos { get; set; }
        public IReadOnlyList<ProductListDto> ProductListDtos { get; set; }

    }
}
