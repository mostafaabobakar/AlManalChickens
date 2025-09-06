using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.PartnersSuccess;
using AlManalChickens.Infrastructure.Extension;
using AlManalChickens.Services.DashBoard.Contract.PartnersSuccessInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.DashBoard
{
    [AuthorizeRolesAttribute(Roles.Admin, Roles.PartnersSuccess)]
    public class PartnersSuccessController : Controller
    {
        private readonly IPartnersSuccessServices _partnersSuccessServices;

        public PartnersSuccessController(IPartnersSuccessServices partnersSuccessServices)
        {
            _partnersSuccessServices = partnersSuccessServices;
        }

        public async Task<IActionResult> Index()
        {
            var listPartners = await _partnersSuccessServices.ListPartnersSuccess();
            return View(listPartners);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePartnerSuccess model)
        {
            var result = await _partnersSuccessServices.CreatePartnersSuccess(model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var partnersSuccess = await _partnersSuccessServices.GetPartnersSuccessById(id);
            return View(partnersSuccess);
        }
        [HttpPost]
        public async Task<IActionResult> Update(GetPartnersSuccessById model)
        {
            var result = await _partnersSuccessServices.UpdatePartnersSuccess(new UpdatePartnersSuccess
            {
                Id = model.Id,
                Name = model.Name,
                NewImage=model.NewImage,

            });
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var result=await _partnersSuccessServices.ChangeStatus(id);    
            return Json(new { data = result});
        }
        public async Task<IActionResult> DeletePartner(int id)
        {
            var result = await _partnersSuccessServices.DeletePartner(id);
            return Json(new { data = result });
        }

    }
}
