using AlManalChickens.Domain.ViewModel.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DashBoard.Contract.NewsInterfaces
{
    public interface INewsServices
    {
        Task<List<GetNewsViewModel>> GetNewsList();
        Task<bool> CreateNews(CreateNewsViewModel model);
        Task<GetNewsByIdViewModel> GetNewsById(int id);
        Task<bool> UpdateNews(GetNewsByIdViewModel model);
        Task<bool> ChangeStatus(int id);
        Task<bool> Delete(int id);
    }
}
