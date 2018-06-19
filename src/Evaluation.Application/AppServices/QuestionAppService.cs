using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evaluation.Application.AppServices.Interfaces;
using Evaluation.Application.ViewModels;
using Evaluation.Domain.Model.Entities;
using Evaluation.Domain.Model.Interfaces.Services;
using Evaluation.Domain.Model.Interfaces.UnitOfWork;

namespace Evaluation.Application.AppServices
{
    public class QuestionAppService : BaseAppService<IQuestionService, Question, QuestionViewModel>, IQuestionAppService
    {
        public QuestionAppService(IQuestionService repository, IUnitOfWork uow, IMapper mapper) : base(repository, uow, mapper)
        {
        }
    }
}
