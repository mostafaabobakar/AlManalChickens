using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.PartnersSuccess;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.PartnersSuccessInterfaces;
using AlManalChickens.Services.DTO.partnersSuccess;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.Record;
using NPOI.OpenXmlFormats.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlManalChickens.Services.DashBoard.Implementation.PartnersSuccessImplementation
{
    public class PartnersSuccessServices : IPartnersSuccessServices
    {
        private readonly ApplicationDbContext _context;

        private readonly IHelper _uploadImage;
        public PartnersSuccessServices(ApplicationDbContext context, IHelper uploadImage)
        {
            _context = context;
            _uploadImage = uploadImage;
        }
        public async Task<List<ListPartnersSuccessViewModel>> ListPartnersSuccess()
        {
            var listPartnersSuccess = await _context.PartnersSuccesses
                .Where(c => !c.IsDelete)
                .Select(c => new ListPartnersSuccessViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = DefaultPath.DomainUrl + c.Image,
                    IsActive = c.IsActive
                }).ToListAsync();
            return listPartnersSuccess;
        }
        public async Task<bool> CreatePartnersSuccess(CreatePartnerSuccess model)
        {
            await _context.PartnersSuccesses.AddAsync(new Domain.Entities.SettingTables.PartnersSuccess
            {
                Name = model.Name,
                Image = _uploadImage.Upload(model.Image, (int)FileName.PartnersSuccess),
                IsActive=true
            });
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<GetPartnersSuccessById> GetPartnersSuccessById(int id)
        {
            var partnersSuccess = await _context.PartnersSuccesses.Where(c => c.Id == id)
                 .Select(c => new GetPartnersSuccessById
                 {
                     Id = c.Id,
                     Name = c.Name,
                     Image = DefaultPath.DomainUrl + c.Image
                 }).FirstOrDefaultAsync();
            return partnersSuccess;
        }
        public async Task<bool> UpdatePartnersSuccess(UpdatePartnersSuccess model)
        {
            var partnersSuccess = await _context.PartnersSuccesses.FindAsync(model.Id);
            partnersSuccess.Name = model.Name;
            partnersSuccess.Image = model.NewImage is not null ? _uploadImage.Upload(model.NewImage, (int)FileName.PartnersSuccess) : partnersSuccess.Image;
            _context.PartnersSuccesses.Update(partnersSuccess);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<PartnersSuccessDto>> GetActivePartnersSuccess()
        {
            var activePartnersSuccess = await _context.PartnersSuccesses
                .Where(c => c.IsActive)
                .Select(c => new PartnersSuccessDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Image = DefaultPath.DomainUrl + c.Image
                }).ToListAsync();
            return activePartnersSuccess;
        }
        public async Task<bool> ChangeStatus(int id)
        {
            var partnersSuccess = await _context.PartnersSuccesses.FindAsync(id);
            partnersSuccess.IsActive = !partnersSuccess.IsActive;
            _context.PartnersSuccesses.Update(partnersSuccess);
            await _context.SaveChangesAsync();
            return partnersSuccess.IsActive;
        }
        public async Task<bool> DeletePartner(int id)
        {
            var DeletedPartners=await _context.PartnersSuccesses.FindAsync(id);
            if (DeletedPartners is  not null)
            {
                _context.PartnersSuccesses.Remove(DeletedPartners);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
