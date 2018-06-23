using System;
using System.Collections.Generic;
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

namespace Evaluation.AdminUi.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminUiQuestionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminUiQuestionService.svc or AdminUiQuestionService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class AdminUiQuestionService : IAdminUiQuestionService
    {
        private readonly IQuestionAppService _questionAppService;

        public AdminUiQuestionService()//IQuestionAppService questionAppService)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EvaluationContext>();
            var evaluationContext = new EvaluationContext(optionsBuilder.Options);
            var unitOfWork = new UnitOfWork(evaluationContext);
            var questionRepository = new QuestionRepository(evaluationContext);
            var questionService = new QuestionService(questionRepository);
            var questionAppService = new QuestionAppService(questionService, unitOfWork);
            _questionAppService = questionAppService;
        }

        public async Task<QuestionViewModel> AddAsync(QuestionViewModel obj)
        {
            return await _questionAppService.AddAsync(obj);
        }

        public async Task<QuestionViewModel> FindAsync(Guid id)
        {
            return await _questionAppService.FindAsync(id);
        }

        public IEnumerable<QuestionViewModel> GetAllAsNoTracking()
        {
            return _questionAppService.GetAllAsNoTracking();
        }

        public IEnumerable<QuestionViewModel> GetAll()
        {
            return _questionAppService.GetAll();
        }

        public QuestionViewModel Update(QuestionViewModel obj)
        {
            return _questionAppService.Update(obj);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _questionAppService.RemoveAsync(id);
        }
    }
}