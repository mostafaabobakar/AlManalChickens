using AlManalChickens.Domain.ViewModel.Cities;

namespace AlManalChickens.Services.DashBoard.Contract.CitiesInterfaces
{
    public interface ICityServices
    {
        Task<List<CitiesViewModel>> GetAllCities();
        Task<bool> CreateCity(CreateCityViewModel City);
        Task<EditCityViewModel> GetCityDetails(int? Id);
        Task<bool> EditCity(EditCityViewModel City);
        Task<bool> ChangeState(int? id);

    }
}
