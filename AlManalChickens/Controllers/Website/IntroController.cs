using AlManalChickens.Services.DashBoard.Contract.CategoryInterfaces;
using AlManalChickens.Services.DashBoard.Contract.ProductsInterfaces;
using AlManalChickens.Services.DashBoard.Contract.SliderInterfaces;
using AlManalChickens.Services.DashBoard.Implementation.SliderImplementaion;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.Record.Chart;

namespace AlManalChickens.Controllers.Website
{
    public class IntroController : Controller
    {
        private readonly ISliderServices _sliderServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IProductServices _productServices;

        public IntroController(ISliderServices sliderServices, ICategoryServices categoryServices, IProductServices productServices)
        {
            _sliderServices = sliderServices;
            _categoryServices = categoryServices;
            _productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            var sliders=await _sliderServices.GetAllSliders();
            return View(sliders);
        }
        public async Task<IActionResult> AboutAs()
        {
            return View();
        }
        public async Task<IActionResult> ContactUs()
        {
            return View();
        }
        public async Task<IActionResult> Production()
        {
            return View();
        }
        public async Task<IActionResult> PartnersSuccess()
        {
            return View();
        }
        public async Task<IActionResult> Products()
        {
            var categoryList = await _categoryServices.GetActiveCategory();
            ViewBag.listCategory=categoryList;
            var product=await _productServices.GetProductByCategotyId(categoryList.FirstOrDefault().Id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> GetProductbyCategory(int categoryId)
        {
            var products = await _productServices.GetProductByCategotyId(categoryId);
            return PartialView("_ProductListByCategoryPartial", products);
        }
    }
}
