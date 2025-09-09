using AlManalChickens.Domain.ViewModel.ContactUs;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.ContactUsInterfaces;
using AlManalChickens.Services.DTO.ContactusDto;
using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Services.DashBoard.Implementation.ContactUsImplementation
{
    public class ContactUsServices : IContactUsServices
    {
        private readonly ApplicationDbContext _context;

        public ContactUsServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContactUsViewModel>> GetContactUs()
        {
            return await _context.ContactUs.Select(c => new ContactUsViewModel
            {
                Id = c.Id,
                UserName = c.UserName,
                Msg = c.Msg,
                Email = c.Email,
                Date = c.Date.ToString("dd-MM-yyyy")
            }).ToListAsync();
        }
        public async Task<bool> CreateContactus(CreateContacusDto model)
        {
            await _context.ContactUs.AddAsync(new Domain.Entities.SettingTables.ContactUs
            {
                UserName = model.userName,
                Email = model.email,
                PhoneNumber = model.phoneNumber,
                Msg = model.message,
                Region = model.region,
                Type = model.contactusType,
                Gender = model.gender,
                Date = DateTime.Now,
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContactUs(int? id)
        {
            var contact = await _context.ContactUs.FindAsync(id);
            contact.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
