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
    public class BaseAppService<TIService, TEntity, TEntityViewModel> : IBaseAppService<TEntityViewModel>
        where TEntity : BaseEntity
        where TEntityViewModel : BaseViewModel
        where TIService : IBaseService<TEntity>
    {
        private readonly TIService _baseService;
        protected readonly IUnitOfWork Uow;
        protected readonly IMapper Mapper;

        public BaseAppService(TIService baseService, IUnitOfWork uow, IMapper mapper)
        {
            _baseService = baseService;
            Uow = uow;
            Mapper = mapper;
        }

        public virtual Task<TEntityViewModel> AddAsync(TEntityViewModel obj)
        {
            Uow.BeginTransaction();
            var ret = _baseService.AddAsync(Mapper.Map<TEntity>(obj));
            Uow.CommitAsync();
            return Mapper.Map<Task<TEntityViewModel>>(ret);
        }

        public virtual Task<TEntityViewModel> FindAsync(Guid id)
        {
            return Mapper.Map<Task<TEntityViewModel>>(_baseService.FindAsync(id));
        }

        public virtual IEnumerable<TEntityViewModel> GetAllAsNoTracking()
        {
            return Mapper.Map<IQueryable<TEntityViewModel>>(_baseService.GetAllAsNoTracking());
        }

        public IEnumerable<TEntityViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntityViewModel>>(_baseService.GetAllAsNoTracking().ToList());
        }

        public virtual TEntityViewModel Update(TEntityViewModel obj)
        {
            Uow.BeginTransaction();
            var ret = _baseService.Update(Mapper.Map<TEntity>(obj));
            Uow.Commit();
            return Mapper.Map<TEntityViewModel>(ret);
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
            _baseService.Remove(Mapper.Map<TEntity>(obj));
            Uow.CommitAsync();
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }
    }
}
