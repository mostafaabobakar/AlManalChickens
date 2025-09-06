using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Entities.Logic;
using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Product;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.ProductsInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DashBoard.Implementation.ProductImplementation
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IHelper _uploadImage;
        public ProductServices(ApplicationDbContext context, IHelper uploadImage)
        {
            _context = context;
            _uploadImage = uploadImage;
        }
        public async Task<List<GetProductListViewModel>> GetProductList()
        {
            var categories = await _context.Products.Include(c => c.Category)
                .Where(c => !c.IsDeleted)
                .Select(c => new GetProductListViewModel
                {
                    Id = c.Id,
                    NameAr = c.NameAr,
                    NameEn = c.NameEn,
                    DescriptionAr = c.DescriptionAr,
                    DescriptionEn = c.DescriptionEn,
                    Image = DefaultPath.DomainUrl + c.Image,
                    Price = c.Price,
                    Weigth = c.Weigth,
                    CategoryName = c.Category.NameAr,
                    IsActive = c.IsActive,

                }).ToListAsync();
            return categories;
        }
        public async Task<GetProductListViewModel> GetProductbyId(int id)
        {
            var product = await _context.Products
                 .Where(c => c.Id == id)
                 .Select(c => new GetProductListViewModel
                 {
                     Id = c.Id,
                     NameAr = c.NameAr,
                     NameEn = c.NameEn,
                     DescriptionAr = c.DescriptionAr,
                     DescriptionEn = c.DescriptionEn,
                     Image = DefaultPath.DomainUrl + c.Image,
                     Price = c.Price,
                     DiscountPrice=c.DiscountPrice,
                     Weigth = c.Weigth,
                     CategoryName = c.Category.NameAr,
                     CategoryId=c.CategoryId,
                     IsActive = c.IsActive,
                 }).FirstOrDefaultAsync();
            return product;
        }
        public async Task<List<GetProductListViewModel>> GetProductByCategotyId(int categoryId)
        {
           var productList=await _context.Products
                .Where(c => c.CategoryId == categoryId && c.IsActive && !c.IsDeleted)
                .Select(c => new GetProductListViewModel
                {
                    Id=c.Id,
                    NameAr = c.NameAr,
                    NameEn = c.NameEn,
                    DescriptionAr = c.DescriptionAr,
                    DescriptionEn = c.DescriptionEn,
                    Image = DefaultPath.DomainUrl + c.Image,
                    Price = c.Price,
                    DiscountPrice = c.DiscountPrice,
                    Weigth = c.Weigth,
                    CategoryName = c.Category.NameAr,
                    CategoryId = c.CategoryId,
                    IsActive = c.IsActive,
                }).ToListAsync();
            return productList;
        }
        public async Task<bool> CreateProduct(CreateProductViewModel model)
        {
            var product = new Product
            {
                NameAr = model.NameAr,
                NameEn = model.NameEn,
                DescriptionAr = model.DescriptionAr,
                DescriptionEn = model.DescriptionEn,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                Weigth = model.Weigth,
                Image = model.Image != null ? _uploadImage.Upload(model.Image, (int)FileName.Products) : "",
                CategoryId = model.CategoryId,
                Date = DateTime.Now,
                IsActive = true,
            };
            await _context.Products.AddAsync(product);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public async Task<bool> UpdateProduct(UpdateProductViewModel model)
        {
            var product=await _context.Products.FindAsync(model.Id);
            product.NameAr = model.NameAr;
            product.NameEn = model.NameEn;
            product.DescriptionAr = model.DescriptionAr;
            product.DescriptionEn = model.DescriptionEn;
            product.Price = model.Price;
            product.DiscountPrice = model.DiscountPrice;
            product.Weigth= model.Weigth;
            product.CategoryId=model.CategoryId;
            product.Image = model.Image is not null ? _uploadImage.Upload(model.Image, (int)FileName.Products) : product.Image;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;    
        }
        public async Task<bool> ChangeState(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null)
            {
                product.IsActive = !product.IsActive;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null)
            {
                product.IsActive = false;
                product.IsDeleted = true;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
