using AlManalChickens.Domain.ViewModel.ContactUs;
using AlManalChickens.Services.DTO.ContactusDto;

namespace AlManalChickens.Services.DashBoard.Contract.ContactUsInterfaces
{
    public interface IContactUsServices
    {
        Task<List<ContactUsViewModel>> GetContactUs();
        Task<bool> CreateContactus(CreateContacusDto model);
        Task<bool> DeleteContactUs(int? id);
    }
}
