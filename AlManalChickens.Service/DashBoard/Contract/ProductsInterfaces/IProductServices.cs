
using AlManalChickens.Domain.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DashBoard.Contract.ProductsInterfaces
{
    public interface IProductServices
    {
        Task<List<GetProductListViewModel>> GetProductList();
        Task<GetProductListViewModel> GetProductbyId(int id);
        Task<List<GetProductListViewModel>> GetProductByCategotyId(int categoryId);
        Task<bool> CreateProduct(CreateProductViewModel model);
        Task<bool> UpdateProduct(UpdateProductViewModel model);
        Task<bool> ChangeState(int id);
        Task<bool> DeleteProduct(int id);
    }
}
