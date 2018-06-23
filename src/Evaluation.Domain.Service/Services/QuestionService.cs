using Evaluation.Domain.Model.Entities;
using Evaluation.Domain.Model.Interfaces.Repositories;
using Evaluation.Domain.Model.Interfaces.Services;

namespace Evaluation.Domain.Service.Services
{
    public class QuestionService : BaseService<Question>, IQuestionService
    {
        public QuestionService(IQuestionRepository repository) : base(repository)
        {
        }
    }
}