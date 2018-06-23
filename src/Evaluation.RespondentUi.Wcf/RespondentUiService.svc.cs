using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Evaluation.Application.AppServices;
using Evaluation.Application.AppServices.Interfaces;
using Evaluation.Application.ViewModels;
using Evaluation.Domain.Model.Entities;
using Evaluation.Domain.Model.Interfaces.Services;
using Evaluation.Domain.Model.Interfaces.UnitOfWork;
using Evaluation.Domain.Service.Services;
using Evaluation.Infrastructure.Data.Context;
using Evaluation.Infrastructure.Data.Repositories;
using Evaluation.Infrastructure.Data.UoW;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.RespondentUi.Wcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
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

        private static IQuestionAppService _questionAppService;
        private static IQuestionService _questionService;
        private static IUnitOfWork _unitOfWork;
        private static void InstantiateQuestionAppServiceSingleton()
        {
            var optionsBuilder = new DbContextOptionsBuilder<EvaluationContext>();
            var evaluationContext = new EvaluationContext(optionsBuilder.Options);

            _unitOfWork = new UnitOfWork(evaluationContext);
            var questionRepository = new QuestionRepository(evaluationContext);
            _questionService = new QuestionService(questionRepository);
            _questionAppService = new QuestionAppService(_questionService, _unitOfWork);
        }

        public async Task CommitAsync()
        {
            await _unitOfWork.CommitAsync();
        }
        public async Task<QuestionViewModel> AddWithoutCommitAsync(QuestionViewModel obj)
        {
            if (_questionAppService == null)
            {
                InstantiateQuestionAppServiceSingleton();
            }
            try
            {
                var question = new Question
                {
                    Id = obj.Id,
                    Text = obj.Text
                };
                await _questionService.AddAsync(question);
                return obj;
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }

            //return await _questionAppService.AddAsync(obj);
        }
    }
}