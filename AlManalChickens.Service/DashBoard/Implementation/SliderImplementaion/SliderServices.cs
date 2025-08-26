using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Slider;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.SliderInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Services.DashBoard.Implementation.SliderImplementaion
{
    public class SliderServices : ISliderServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IHelper _uploadImage;

        public SliderServices(ApplicationDbContext context, IHelper uploadImage)
        {
            _context = context;
            _uploadImage = uploadImage;
        }


        public async Task<List<SliderViewModel>> GetAllSliders()
        {
            var Sliders = await _context.Sliders
                .Where(c => c.IsActive && (c.ExpireDate != null ? c.ExpireDate.Value.Date > DateTime.Now.Date : true))
                .Select(s => new SliderViewModel
                {
                    Id = s.Id,
                    //SliderName = s.SliderName,
                    Url = s.Url,
                    Image = DefaultPath.DomainUrl + s.Image,
                    IsActive = s.IsActive,
                    CreationDate = s.CreationDate.ToString("dd-MM-yyyy"),
                    ExpireDate = s.ExpireDate != null ? s.ExpireDate.Value.ToString("dd-MM-yyyy") : "",
                }).ToListAsync();
            return Sliders;
        }
        public async Task<bool> CreateSlider(CreateSliderViewModel slider)
        {
            Slider NewSlider = new Slider
            {
                //SliderName = slider.SliderName,
                Url = slider.Url,
                Image = slider.Image != null ? _uploadImage.Upload(slider.Image, (int)FileName.Slider) : "",
                IsActive = true,
                CreationDate = DateTime.Now,
                ExpireDate = slider.ExpireDate,
            };
            _context.Sliders.Add(NewSlider);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<EditSliderViewModel> GetSliderDetails(int? Id)
        {
            return await _context.Sliders.Where(s => s.Id == Id).Select(s => new EditSliderViewModel
            {
                Id = s.Id,
                //SliderName = s.SliderName,
                Url = s.Url,
                CurrentImage = DefaultPath.DomainUrl + s.Image,
                ExpireDate = s.ExpireDate,
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> EditSlider(EditSliderViewModel slider)
        {
            try
            {
                var current = await _context.Sliders.FirstOrDefaultAsync(a => a.Id == slider.Id);

                //current.SliderName = slider.SliderName;
                current.Url = slider.Url;
                current.Image = slider.NewImage != null ? _uploadImage.Upload(slider.NewImage, (int)FileName.Slider) : current.Image;
                current.ExpireDate = slider.ExpireDate;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertismentExists(slider.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

        }

        private bool AdvertismentExists(int id)
        {
            return _context.Sliders.Any(e => e.Id == id);
        }

        public async Task<bool> ChangeState(int? id)
        {
            var Slider = await _context.Sliders.FindAsync(id);
            Slider.IsActive = !Slider.IsActive;
            await _context.SaveChangesAsync();
            return Slider.IsActive;
        }
        public async Task<bool> Delete(int? id)
        {
            var deletedSlider = await _context.Sliders.FindAsync(id);
            if (deletedSlider is not null)
            {
                _context.Sliders.Remove(deletedSlider);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
