using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.SocialMedia;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.SocialMediaInterfases;
using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Services.DashBoard.Implementation.SocialMediaImplementation
{
    public class SocialMediaServices : ISocialMediaServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IHelper _uploadImage;
        public SocialMediaServices(ApplicationDbContext context, IHelper uploadImage)
        {
            _context = context;
            _uploadImage = uploadImage;
        }

        public async Task<List<SocialMediaViewModel>> GetSocialMedia()
        {
            var SocialMedia = await _context.SocialMedia
                                            .Select(s => new SocialMediaViewModel
                                            {
                                                Id = s.Id,
                                                NameAr = s.NameAr,
                                                NameEn = s.NameEn,
                                                URL = s.Url,
                                                Image = DefaultPath.DomainUrl + s.Image,
                                                IsActive = s.IsActive
                                            }).ToListAsync();
            return SocialMedia;
        }
        public async Task<bool> CreateSocialMedia(SocialMediaAddViewModel model)
        {
            SocialMedia newadvertisement = new SocialMedia
            {
                NameAr = model.NameAr,
                NameEn = model.NameEn,
                Url = model.Url,
                Image = model.Img != null ? _uploadImage.Upload(model.Img, (int)FileName.SocialMedia) : "",
                IsActive = true,
                Date = DateTime.Now,
            };
            _context.Add(newadvertisement);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<SocialMediaEditViewModel> GetSocialMediaDetails(int? id)
        {
            var socialMedia = await _context.SocialMedia.FindAsync(id);

            SocialMediaEditViewModel editSocialMediaViewModel = new SocialMediaEditViewModel
            {
                Id = socialMedia.Id,
                NameAr = socialMedia.NameAr,
                NameEn = socialMedia.NameEn,
                Url = socialMedia.Url,
                CurrentImage = DefaultPath.DomainUrl + socialMedia.Image,
            };

            return editSocialMediaViewModel;
        }

        public async Task<bool> EditSocialMediaDetails(SocialMediaEditViewModel editSocialMediaViewModel)
        {
            try
            {
                var current = await _context.SocialMedia.FirstOrDefaultAsync(a => a.Id == editSocialMediaViewModel.Id);
                current.Id = editSocialMediaViewModel.Id;
                current.NameAr = editSocialMediaViewModel.NameAr;
                current.NameEn = editSocialMediaViewModel.NameEn;
                current.Url = editSocialMediaViewModel.Url;
                current.Image = editSocialMediaViewModel.NewImage != null ? _uploadImage.Upload(editSocialMediaViewModel.NewImage, (int)FileName.SocialMedia) : current.Image;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialMediaExists(editSocialMediaViewModel.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
        private bool SocialMediaExists(int id)
        {
            return _context.SocialMedia.Any(e => e.Id == id);
        }

        public async Task<bool> ChangeState(int? id)
        {
            var socialMedia = await _context.SocialMedia.FindAsync(id);
            socialMedia.IsActive = !socialMedia.IsActive;
            await _context.SaveChangesAsync();
            return socialMedia.IsActive;
        }
    }
}
