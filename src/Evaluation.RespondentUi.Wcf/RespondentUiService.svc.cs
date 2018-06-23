using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Evaluation.Application.AppServices;
using Evaluation.Application.AppServices.Interfaces;
using Evaluation.Application.ViewModels;
using Evaluation.Domain.Service.Services;
using Evaluation.Infrastructure.Data.Context;
using Evaluation.Infrastructure.Data.Repositories;
using Evaluation.Infrastructure.Data.UoW;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.RespondentUi.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RespondentUiService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RespondentUiService.svc or RespondentUiService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        IncludeExceptionDetailInFaults = true)]
    public class RespondentUiService : IRespondentUiService
    {
        //private readonly IQuestionAppService _questionAppService;
        
        //public RespondentUiService(IQuestionAppService questionAppService)
        //{
        //    _questionAppService = questionAppService;
        //}

        public async Task<QuestionViewModel> AddAsync(QuestionViewModel obj)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<EvaluationContext>();
                using (var evaluationContext = new EvaluationContext(optionsBuilder.Options))
                {
                    var unitOfWork = new UnitOfWork(evaluationContext);
                    var questionRepository = new QuestionRepository(evaluationContext);
                    var questionService = new QuestionService(questionRepository);
                    var questionAppService = new QuestionAppService(questionService, unitOfWork);

                    return await questionAppService.AddAsync(obj);
                }
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }

            //return await _questionAppService.AddAsync(obj);
        }
    }
}