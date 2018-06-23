using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evaluation.Application.AppServices.Interfaces;
using Evaluation.Application.AutoMapper;
using Evaluation.Application.ViewModels;
using Evaluation.Domain.Model.Entities;
using Evaluation.Domain.Model.Interfaces.Services;
using Evaluation.Domain.Model.Interfaces.UnitOfWork;

namespace Evaluation.Application.AppServices
{
    public class BaseAppService<TIService, TEntity, TEntityViewModel> : IBaseAppService<TEntityViewModel>
        where TEntity : BaseEntity
        where TEntityViewModel : BaseViewModel
        where TIService : IBaseService<TEntity>
    {
        private readonly TIService _baseService;
        protected readonly IMapper AutoMapper;
        protected readonly IUnitOfWork Uow;

        public BaseAppService(TIService baseService, IUnitOfWork uow)//, IMapper autoMapper)
        {
            _baseService = baseService;
            Uow = uow;
            AutoMapper = new Mapper(AutoMapperConfig.RegisterMappings());// autoMapper;
        }

        public virtual Task<TEntityViewModel> AddAsync(TEntityViewModel obj)
        {
            Uow.BeginTransaction();
            var ret = _baseService.AddAsync(AutoMapper.Map<TEntity>(obj));
            Uow.CommitAsync();
            return AutoMapper.Map<Task<TEntityViewModel>>(ret);
        }

        public virtual Task<TEntityViewModel> FindAsync(Guid id)
        {
            return AutoMapper.Map<Task<TEntityViewModel>>(_baseService.FindAsync(id));
        }

        public virtual IEnumerable<TEntityViewModel> GetAllAsNoTracking()
        {
            return AutoMapper.Map<IQueryable<TEntityViewModel>>(_baseService.GetAllAsNoTracking());
        }

        public IEnumerable<TEntityViewModel> GetAll()
        {
            return AutoMapper.Map<IEnumerable<TEntityViewModel>>(_baseService.GetAllAsNoTracking().ToList());
        }

        public virtual TEntityViewModel Update(TEntityViewModel obj)
        {
            Uow.BeginTransaction();
            var ret = _baseService.Update(AutoMapper.Map<TEntity>(obj));
            Uow.Commit();
            return AutoMapper.Map<TEntityViewModel>(ret);
        }

        public virtual Task RemoveAsync(Guid id)
        {
            Uow.BeginTransaction();
            var ret = _baseService.RemoveAsync(id);
            Uow.CommitAsync();
            return ret;
        }

        public virtual void Remove(TEntityViewModel obj)
        {
            Uow.BeginTransaction();
            _baseService.Remove(AutoMapper.Map<TEntity>(obj));
            Uow.CommitAsync();
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }
    }
}