using AlManalChickens.Services.DTO.More;

namespace AlManalChickens.Services.Api.Contract.More
{
    public interface IMoreService
    {
        Task<AboutUsDto> AboutUs(string lang = "ar");
        Task<List<CommonQuestionsDto>> CommonQuestions(string lang = "ar");
        Task<TermsAndConditionsDto> TermsAndConditions(string lang = "ar");
        Task<bool> ContactWithUs(ContactWithUsDto contactWithUs);
    }
}
