using AlManalChickens.Domain.Entities.Cities_Tables;
using AlManalChickens.Domain.ViewModel.Cities;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.CitiesInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Services.DashBoard.Implementation.CitiesImplementation
{
    public class CityServices : ICityServices
    {
        private readonly ApplicationDbContext _context;

        public CityServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CitiesViewModel>> GetAllCities()
        {
            var cities = await _context.Cities.Select(x => new CitiesViewModel
            {
                Id = x.Id,
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                IsActive = x.IsActive,
            }).ToListAsync();

            return cities;
        }

        public async Task<bool> CreateCity(CreateCityViewModel createCityViewModel)
        {
            City city = new City()
            {
                Date = DateTime.Now,
                NameAr = createCityViewModel.NameAr,
                NameEn = createCityViewModel.NameEn,
                IsActive = true,
            };
            await _context.Cities.AddAsync(city);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<EditCityViewModel> GetCityDetails(int? Id)
        {
            return await _context.Cities.Where(c => c.Id == Id)
                                            .Select(c => new EditCityViewModel
                                            {
                                                Id = c.Id,
                                                NameAr = c.NameAr,
                                                NameEn = c.NameEn,
                                            }).FirstOrDefaultAsync();
        }

        public async Task<bool> EditCity(EditCityViewModel editCityViewModel)
        {
            City city = await _context.Cities.FindAsync(editCityViewModel.Id);
            if (city == null)
                return false;

            city.NameAr = editCityViewModel.NameAr;
            city.NameEn = editCityViewModel.NameEn;
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeState(int? id)
        {
            City city = await _context.Cities.FindAsync(id);
            city.IsActive = !city.IsActive;
            await _context.SaveChangesAsync();

            return city.IsActive;
        }
    }
}
