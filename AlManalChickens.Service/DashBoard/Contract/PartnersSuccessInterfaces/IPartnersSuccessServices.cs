using AlManalChickens.Domain.ViewModel.PartnersSuccess;
using AlManalChickens.Services.DTO.partnersSuccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DashBoard.Contract.PartnersSuccessInterfaces
{
    public interface IPartnersSuccessServices
    {
        Task<List<ListPartnersSuccessViewModel>> ListPartnersSuccess();
        Task<bool> CreatePartnersSuccess(CreatePartnerSuccess model);
        Task<GetPartnersSuccessById> GetPartnersSuccessById(int id);
        Task<bool> UpdatePartnersSuccess(UpdatePartnersSuccess model);
        Task<PartnersSuccessDto> GetActivePartnersSuccess();
        Task<bool> ChangeStatus(int id);
        Task<bool> DeletePartner(int id);

    }
}
