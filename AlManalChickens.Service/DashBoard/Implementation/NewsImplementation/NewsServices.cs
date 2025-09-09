using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.News;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.NewsInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DashBoard.Implementation.NewsImplementation
{
    public class NewsServices : INewsServices
    {
        private readonly ApplicationDbContext _context;

        private readonly IHelper _uploadImage;
        public NewsServices(ApplicationDbContext context, IHelper uploadImage = null)
        {
            _context = context;
            _uploadImage = uploadImage;
        }
        public async Task<List<GetNewsViewModel>> GetNewsList()
        {
            var listNews = await _context.News.Where(c => !c.IsDeleted).Select(c => new GetNewsViewModel
            {
                Id = c.Id,
                Title = c.Title,
                Text = c.Text,
                Image = DefaultPath.DomainUrl + c.Image,
                IsActive = c.IsActive,
            }).ToListAsync();
            return listNews;
        }
        public async Task<bool> CreateNews(CreateNewsViewModel model)
        {
            await _context.News.AddAsync(new Domain.Entities.SettingTables.News
            {
                Title = model.Title,
                Text = model.Text,
                Image = _uploadImage.Upload(model.Image, (int)FileName.News),
                IsActive = true
            });
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<GetNewsByIdViewModel> GetNewsById(int id)
        {
            var newsById = await _context.News
                .Where(c => c.Id == id)
                .Select(c => new GetNewsByIdViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Text = c.Text,
                    Image = DefaultPath.DomainUrl + c.Image,
                    IsActive = c.IsActive,
                }).FirstOrDefaultAsync();
            return newsById;
        }
        public async Task<bool> UpdateNews(GetNewsByIdViewModel model)
        {
            var news = await _context.News.FindAsync(model.Id);
            news.Title = model.Title;
            news.Text = model.Text;
            news.Image = model.Image is not null ? _uploadImage.Upload(model.Image, (int)FileName.News) : news.Image;
            _context.Update(news);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ChangeStatus(int id)
        {
            var news = await _context.News.FindAsync(id);
            news.IsActive = !news.IsActive;
            _context.Update(news);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var news=await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
