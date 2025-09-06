using AlManalChickens.Domain.ViewModel.Category;
using AlManalChickens.Services.DTO.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DashBoard.Contract.CategoryInterfaces
{
    public interface ICategoryServices
    {
        Task<List<GetCategoryListViewModel>> GetCategoryList();
        Task<GetCategoryByIdViewModel> GetCategoryById(int id);
        Task<List<GetCategoryLookUpViewModel>> GetCategoryLookUp();
        Task<List<CategoryListDto>> GetActiveCategory();
        Task<bool> CreateCategory(CreateCategoryViewModel model);
        Task<bool> UpdateCategory(UpdateCategoryViewModel model);
        Task<bool> ChangeStatus(int id);
        Task<bool> Delete(int id);
    }
}
