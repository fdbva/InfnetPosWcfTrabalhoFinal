using Evaluation.Domain.Model.Entities;
using Evaluation.Domain.Model.Interfaces.Repositories;
using Evaluation.Infrastructure.Data.Context;

namespace Evaluation.Infrastructure.Data.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(EvaluationContext context) : base(context)
        {
        }
    }
}