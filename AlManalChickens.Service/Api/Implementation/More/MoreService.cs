using AlManalChickens.Domain.Entities.SettingTables;
using AlManalChickens.Persistence;
using AlManalChickens.Services.Api.Contract.More;
using AlManalChickens.Services.Api.Implementation.General;
using AlManalChickens.Services.DTO.More;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Services.Api.Implementation.More
{
    public class MoreService : ApplicationService, IMoreService
    {
        private readonly ApplicationDbContext _db;

        public MoreService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db) : base(httpContextAccessor)
        {
            _db = db;
        }

        public async Task<AboutUsDto> AboutUs(string lang = "ar")
        {
            AboutUsDto aboutUsDto = new AboutUsDto()
            {
                aboutUs = await _db.Settings
                                   .Select(a => lang == "ar" ? a.AboutUsArClient : a.AboutUsEnClient)
                                   .FirstOrDefaultAsync()
            };

            // for testing purposes only, Inherit from ApplicationService to get the current userId and language,
            // instead of getting them as parameters form controller
            var language = Lang;
            var userId = UserId;

            return aboutUsDto;
        }

        public async Task<List<CommonQuestionsDto>> CommonQuestions(string lang = "ar")
        {
            var question = await _db.Questions
                                    .Select(q => new CommonQuestionsDto()
                                    {
                                        Question = lang == "ar" ? q.QuestionAr : q.QuestionEn,
                                        Answer = lang == "ar" ? q.AnswerAr : q.AnswerEn
                                    }).ToListAsync();

            return question;
        }

        public async Task<TermsAndConditionsDto> TermsAndConditions(string lang = "ar")
        {
            var termsAndCondition = await _db.Settings.Select(t => new TermsAndConditionsDto()
            {
                TermAndCondition = lang == "ar" ? t.CondtionsArClient : t.CondtionsEnClient
            }).FirstOrDefaultAsync();

            return termsAndCondition;
        }

        public async Task<bool> ContactWithUs(ContactWithUsDto contactWithUsDto)
        {
            ContactUs contactWithUs = new ContactUs()
            {
                UserName = contactWithUsDto.UserName,
                Msg = contactWithUsDto.Message,
                Email = contactWithUsDto.Email,
                Date = DateTime.Now
            };

            await _db.AddAsync(contactWithUs);
            return await _db.SaveChangesAsync() > 0 ? true : false;
        }

    }
}
