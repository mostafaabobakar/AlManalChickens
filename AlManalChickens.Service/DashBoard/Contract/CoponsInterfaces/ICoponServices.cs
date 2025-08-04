using AlManalChickens.Domain.Entities.Copon;
using AlManalChickens.Domain.ViewModel.Copon;

namespace AlManalChickens.Services.DashBoard.Contract.CoponsInterfaces
{
    public interface ICoponServices
    {
        Task<List<CoponViewModel>> GetCopons();
        Task<bool> CreateCopon(CoponCreateViewModel createCoponViewModel);
        Task<Copon> GetCopon(int? CoponId);
        Task<bool> EditCopon(int id, CoponCreateViewModel createCoponViewModel);
        bool IsExist(string CoponCode);
        bool IsExist(int? CoponId);
        Task<bool> ChangeState(int? id);
        Task<bool> DeleteCopons(int? id);

    }
}
