using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Slider;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.SliderInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRolesAttribute(Roles.Admin, Roles.Slider)]
    public class SlidersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHelper _uploadImage;
        private readonly ISliderServices _sliderServices;
        private readonly HttpContext _httpContext;

        public SlidersController(ApplicationDbContext context, IHelper uploadImage, ISliderServices sliderServices)
        {
            _context = context;
            _uploadImage = uploadImage;
            _sliderServices = sliderServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _sliderServices.GetAllSliders());
        }

        // GET: Slider/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSliderViewModel slider)
        {
            if (ModelState.IsValid)
            {
                if (await _sliderServices.CreateSlider(slider))
                    return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Slider = await _sliderServices.GetSliderDetails(id);
            if (Slider == null)
            {
                return NotFound();
            }

            return View(Slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditSliderViewModel slider)
        {
            if (ModelState.IsValid)
            {
                if (await _sliderServices.EditSlider(slider))
                    return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            bool IsActive = await _sliderServices.ChangeState(id);

            return Json(new { key = 1, data = IsActive });
        }
    }
}
