using AlManalChickens.Domain.ViewModel.Question;

namespace AlManalChickens.Services.DashBoard.Contract.QuestionsInterfaces
{
    public interface IQuestionServices
    {
        Task<List<QuestionViewModel>> GetQuestions();
        Task<bool> CreateQuestion(CreateQuestionViewModel questionViewModel);
        Task<QuestionViewModel> GetQuestionDetails(int? id);
        Task<bool> EditQuestion(QuestionViewModel questionViewModel);
        Task<bool> ChangeState(int? id);
        bool QuestionsExists(int? id);

    }
}
