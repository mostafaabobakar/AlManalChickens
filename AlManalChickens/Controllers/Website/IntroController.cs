using AlManalChickens.Services.DashBoard.Contract.CategoryInterfaces;
using AlManalChickens.Services.DashBoard.Contract.ContactUsInterfaces;
using AlManalChickens.Services.DashBoard.Contract.PartnersSuccessInterfaces;
using AlManalChickens.Services.DashBoard.Contract.ProductsInterfaces;
using AlManalChickens.Services.DashBoard.Contract.SliderInterfaces;
using AlManalChickens.Services.DashBoard.Implementation.SliderImplementaion;
using AlManalChickens.Services.DTO.ContactusDto;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.Record.Chart;

namespace AlManalChickens.Controllers.Website
{
    public class IntroController : Controller
    {
        private readonly ISliderServices _sliderServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IProductServices _productServices;
        private readonly IPartnersSuccessServices _partnersSuccessServices;
        private readonly IContactUsServices _contactUsServices;
        public IntroController(ISliderServices sliderServices, ICategoryServices categoryServices, IProductServices productServices, IPartnersSuccessServices partnersSuccessServices, IContactUsServices contactUsServices)
        {
            _sliderServices = sliderServices;
            _categoryServices = categoryServices;
            _productServices = productServices;
            _partnersSuccessServices = partnersSuccessServices;
            _contactUsServices = contactUsServices;
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
        [HttpPost]
        public async Task<IActionResult> ContactUs(CreateContacusDto model)
        {
            var result=await _contactUsServices.CreateContactus(model);
            return RedirectToAction(nameof(ContactUs));
        }
        public async Task<IActionResult> Production()
        {
            return View();
        }
        public async Task<IActionResult> PartnersSuccess()
        {
            var partnersSuccess = await _partnersSuccessServices.GetActivePartnersSuccess();
            return View(partnersSuccess);
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
