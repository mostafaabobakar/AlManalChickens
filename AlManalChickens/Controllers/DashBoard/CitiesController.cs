using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Cities;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Services.Api.Contract.General;
using AlManalChickens.Services.DashBoard.Contract.CitiesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRolesAttribute(Roles.Admin, Roles.Cities)]
    public class CitiesController : Controller
    {
        private readonly ICityServices _cityServices;
        private readonly IUserContext _userContext;

        public CitiesController( ICityServices cityServices, IUserContext userContext)
        {
            _cityServices = cityServices;
            _userContext = userContext;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            return View(await _cityServices.GetAllCities());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCityViewModel createCityViewModel)
        {
            if (ModelState.IsValid)
            {
                if(await _cityServices.CreateCity(createCityViewModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(createCityViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            var city = await _cityServices.GetCityDetails(Id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCityViewModel editCityViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _cityServices.EditCity(editCityViewModel))
                    return RedirectToAction(nameof(Index));
            }
            return View(editCityViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeState(int? id)
        {
            bool IsActive=await _cityServices.ChangeState(id);
            return Json(new { data = IsActive });
        }


    }
}
