using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Category;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Services.DashBoard.Contract.CategoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;

namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRolesAttribute(Roles.Admin, Roles.Category)]
    public class CategoryController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        public async Task<IActionResult> Index()
        {
            var categoryList = await _categoryServices.GetCategoryList();
            return View(categoryList);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            var result = await _categoryServices.CreateCategory(model);

            if (result)
                return RedirectToAction(nameof(Index));

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryServices.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GetCategoryByIdViewModel model)
        {
            var result = await _categoryServices.UpdateCategory(new UpdateCategoryViewModel
            {
                Id = model.Id,
                NameAr = model.NameAr,
                NameEn = model.NameEn,
            });
            if (result)
                return RedirectToAction(nameof(Index));
            return View(model);
        }
        public async Task<IActionResult> ChangeState(int id)
        {
            var isActive = await _categoryServices.ChangeStatus(id);
            return Json(new { data = isActive });
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryServices.Delete(id);
            return Json(new { data = result });
        }
    }
}
