using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evaluation.Application.AppServices;
using Evaluation.Application.AppServices.Interfaces;
using Evaluation.Domain.Model.Interfaces.Repositories;
using Evaluation.Domain.Model.Interfaces.Services;
using Evaluation.Domain.Model.Interfaces.UnitOfWork;
using Evaluation.Domain.Service.Services;
using Evaluation.Infrastructure.Data.Context;
using Evaluation.Infrastructure.Data.Repositories;
using Evaluation.Infrastructure.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Evaluation.Infrastructure.CrossCutting
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // 2 - Application AutoMapper
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // 2 - Application AppServices
            services.AddScoped(typeof(IQuestionAppService), typeof(QuestionAppService));

            // 3 - Domain Services
            services.AddScoped(typeof(IQuestionService), typeof(QuestionService));

            // 3 - Domain Repositories
            services.AddScoped(typeof(IQuestionRepository), typeof(QuestionRepository));

            // 4.1 - Infra.Data
            services.AddScoped<EvaluationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
