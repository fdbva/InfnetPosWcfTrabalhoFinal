using AutoMapper;
using AutoMapper.Configuration;
using Evaluation.Application.AppServices;
using Evaluation.Application.AppServices.Interfaces;
using Evaluation.Application.AutoMapper;
using Evaluation.Domain.Model.Interfaces.Repositories;
using Evaluation.Domain.Model.Interfaces.Services;
using Evaluation.Domain.Model.Interfaces.UnitOfWork;
using Evaluation.Domain.Service.Services;
using Evaluation.Infrastructure.Data.Context;
using Evaluation.Infrastructure.Data.Repositories;
using Evaluation.Infrastructure.Data.UoW;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;

namespace Evaluation.Infrastructure.CrossCutting
{
    public static class SimpleInjectorBootstrapper
    {
        public static void RegisterServices(Container container)
        {
            // 4.1 - Infra.Data
            container.Register<DbContext, EvaluationContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>();

            // 2 - Application AutoMapper
            container.RegisterSingleton(() => GetMapper(container));
            //container.Register(Mapper.Configuration);
            //container.Register<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // 2 - Application AppServices
            container.Register(typeof(IQuestionAppService), typeof(QuestionAppService));

            // 3 - Domain Services
            container.Register(typeof(IQuestionService), typeof(QuestionService));

            // 3 - Domain Repositories
            container.Register(typeof(IQuestionRepository), typeof(QuestionRepository));

        }

        private static IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        }
    }

    public class MapperProvider
    {
        private readonly Container _container;

        public MapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(_container.GetInstance);

            mce.AddProfiles(typeof(MappingsWithReverse).Assembly);

            var mc = new MapperConfiguration(mce);
            mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => _container.GetInstance(t));

            return m;
        }
    }
}