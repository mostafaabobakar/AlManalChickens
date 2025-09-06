using AlManalChickens.Domain.Entities.Logic;
using AlManalChickens.Domain.ViewModel.Category;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.CategoryInterfaces;
using AlManalChickens.Services.DTO.CategoryDto;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DashBoard.Implementation.CategoryImplementation
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetCategoryListViewModel>> GetCategoryList()
        {
            var categoreList = await _context.Categories.Where(c => !c.IsDeleted)
                .Select(c => new GetCategoryListViewModel
                {
                    Id = c.Id,
                    NameAr = c.NameAr,
                    NameEn = c.NameEn,
                    IsActive = c.IsActive,
                }).ToListAsync();
            return categoreList;
        }
        public async Task<List<CategoryListDto>> GetActiveCategory()
        {
            var categoryList=await _context.Categories
                .Where(c => !c.IsDeleted&&c.IsActive)
                .Select(c => new CategoryListDto
                {
                    Id = c.Id,
                    NameAr = c.NameAr,
                    NameEn = c.NameEn,
                }).ToListAsync();
            return categoryList;
        }
        public async Task<GetCategoryByIdViewModel> GetCategoryById(int id)
        {
            var category = await _context.Categories.Where(c => c.Id == id)
                .Select(c => new GetCategoryByIdViewModel
                {
                    Id = c.Id,
                    NameAr = c.NameAr,
                    NameEn = c.NameEn,
                    IsActive = c.IsActive,
                }).FirstOrDefaultAsync();
            return category;
        }
        public async Task<bool> CreateCategory(CreateCategoryViewModel model)
        {
            var category = new Category
            {
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                NameAr = model.NameAr,
                NameEn = model.NameEN
            };
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCategory(UpdateCategoryViewModel model)
        {
            var category = await _context.Categories.FindAsync(model.Id);
            if (category != null)
            {
                category.NameAr= model.NameAr;
                category.NameEn= model.NameEn;
                _context.Categories.Update(category);
               await  _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<List<GetCategoryLookUpViewModel>> GetCategoryLookUp()
        {
            return await _context.Categories.Where(c => c.IsActive)
                .Select(c => new GetCategoryLookUpViewModel
                {
                     Id=c.Id,
                     Name=c.NameAr
                }).ToListAsync();
        }
        public async Task<bool> ChangeStatus(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            category.IsActive = !category.IsActive;
            await _context.SaveChangesAsync();
            return category.IsActive;
        }
        public async Task<bool> Delete(int id)
        {
            var deletedCategore = await _context.Categories.Include(c => c.Products)
                                .FirstOrDefaultAsync(c => c.Id == id);
            if (deletedCategore.Products is not null || deletedCategore.Products.Where(c=>!c.IsDeleted).Count() > 0)
            {
                return false;
            }
            deletedCategore.IsDeleted = true;
            await _context.SaveChangesAsync();
            return deletedCategore.IsDeleted;

        }
    }
}
