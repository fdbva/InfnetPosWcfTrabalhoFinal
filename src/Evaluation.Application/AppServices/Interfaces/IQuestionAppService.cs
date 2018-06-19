using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation.Application.ViewModels;
using Evaluation.Domain.Model.Entities;

namespace Evaluation.Application.AppServices.Interfaces
{
    public interface IQuestionAppService : IBaseInternalAppService<Question, QuestionViewModel>, IBaseAppService<QuestionViewModel>
    {

    }
}
