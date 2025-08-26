using AlManalChickens.Services.DashBoard.Contract.SliderInterfaces;
using AlManalChickens.Services.DashBoard.Implementation.SliderImplementaion;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.Record.Chart;

namespace AlManalChickens.Controllers.Website
{
    public class IntroController : Controller
    {
        private readonly ISliderServices _sliderServices;

        public IntroController(ISliderServices sliderServices)
        {
            _sliderServices = sliderServices;
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
            return View();
        }
    }
}
