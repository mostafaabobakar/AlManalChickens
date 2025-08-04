using AlManalChickens.Domain.ViewModel.SocialMedia;

namespace AlManalChickens.Services.DashBoard.Contract.SocialMediaInterfases
{
    public interface ISocialMediaServices
    {
        Task<List<SocialMediaViewModel>> GetSocialMedia();
        Task<bool> CreateSocialMedia(SocialMediaAddViewModel model);
        Task<SocialMediaEditViewModel> GetSocialMediaDetails(int? id);
        Task<bool> EditSocialMediaDetails(SocialMediaEditViewModel model);
        Task<bool> ChangeState(int? id);

    }
}
