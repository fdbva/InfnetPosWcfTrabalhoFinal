using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
