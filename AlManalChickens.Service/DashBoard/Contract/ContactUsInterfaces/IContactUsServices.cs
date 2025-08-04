using AlManalChickens.Domain.ViewModel.ContactUs;

namespace AlManalChickens.Services.DashBoard.Contract.ContactUsInterfaces
{
    public interface IContactUsServices
    {
        Task<List<ContactUsViewModel>> GetContactUs();
        Task<bool> DeleteContactUs(int? id);
    }
}
