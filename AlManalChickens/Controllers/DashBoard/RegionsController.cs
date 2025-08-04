using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Regions;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Services.DashBoard.Contract.RegionsInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRolesAttribute(Roles.Admin, Roles.Regoins)]

    public class RegionsController : Controller
    {
        private readonly IRegionServices _regionServices;

        public RegionsController(IRegionServices regionServices)
        {
            _regionServices = regionServices;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            return View(await _regionServices.GetAllRegions());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.city = _regionServices.GetAllCities(); 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRegionViewModel createRegionViewModel)
        {
            if (ModelState.IsValid)
            {
                if(await _regionServices.CreateRegion(createRegionViewModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(createRegionViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            var regoin = await _regionServices.GetRegionDetails(Id);
            if (regoin == null)
            {
                return NotFound();
            }
            ViewBag.city = _regionServices.GetAllCitiesWithSelectedCity(regoin.CityId);

            return View(regoin);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditRegionViewModel editRegionViewModel)
        {
            if (ModelState.IsValid)
            {
                if(await _regionServices.EditRegion(editRegionViewModel))
                    return RedirectToAction(nameof(Index));
            }

            return View(editRegionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            bool IsActive=await _regionServices.ChangeState(id);
            return Json(new { data = IsActive });
        }

    }
}
