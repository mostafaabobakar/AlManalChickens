using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Product;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Services.DashBoard.Contract.CategoryInterfaces;
using AlManalChickens.Services.DashBoard.Contract.ProductsInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRolesAttribute(Roles.Admin, Roles.Products)]

    public class ProductsController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IHelper _uploadImage;
        private readonly IProductServices _productServices;
        public ProductsController(ICategoryServices categoryServices, IHelper uploadImage, IProductServices productServices)
        {
            _categoryServices = categoryServices;
            _uploadImage = uploadImage;
            _productServices = productServices;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productServices.GetProductList());
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categoryLookUp = await _categoryServices.GetCategoryLookUp();
            ViewBag.categoryLookup = categoryLookUp
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                .ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            var categoryLookUp = await _categoryServices.GetCategoryLookUp();
            ViewBag.categoryLookup = categoryLookUp
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
                .ToList();
            if (ModelState.IsValid)
            {
                var result = await _productServices.CreateProduct(model);
                if (result)
                    return RedirectToAction(nameof(Index));

                return View(model);
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productServices.GetProductbyId(id);
            var categoryLookUp = await _categoryServices.GetCategoryLookUp();
            ViewBag.categoryLookup = categoryLookUp
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString(),Selected=c.Id==product.CategoryId })
                .ToList();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GetProductListViewModel model)
        {
            var result = await _productServices.UpdateProduct(new UpdateProductViewModel
            {
                Id = model.Id,
                NameAr = model.NameAr,
                NameEn = model.NameEn,
                DescriptionAr = model.DescriptionAr,
                DescriptionEn = model.DescriptionEn,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                CategoryId = model.CategoryId,
                Weigth = model.Weigth,
                Image = model.NewImage,
            });
            if (result)
                return RedirectToAction(nameof(Index));
            return View(model);
        }
        public async Task<IActionResult> ChangeState(int id)
        {
            var isActive = await _productServices.ChangeState(id);
            return Json(new { data = isActive });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _productServices.DeleteProduct(id);
            return Json(new { data = isDeleted });
        }
    }
}
