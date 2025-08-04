using AlManalChickens.Domain.ViewModel.Regions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlManalChickens.Services.DashBoard.Contract.RegionsInterfaces
{
    public interface IRegionServices
    {
        Task<List<RegionsViewModel>> GetAllRegions();
        List<SelectListItem> GetAllCities();
        List<SelectListItem> GetAllCitiesWithSelectedCity(int CityId);
        Task<bool> CreateRegion(CreateRegionViewModel Region);
        Task<EditRegionViewModel> GetRegionDetails(int? Id);
        Task<bool> EditRegion(EditRegionViewModel Region);
        Task<bool> ChangeState(int? id);

    }
}
