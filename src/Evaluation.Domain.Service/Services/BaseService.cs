using Evaluation.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation.Domain.Model.Interfaces.Repositories;
using Evaluation.Domain.Model.Interfaces.Services;

namespace Evaluation.Domain.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual Task<TEntity> AddAsync(TEntity obj)
        {
            return _repository.AddAsync(obj);
        }

        public virtual Task<TEntity> FindAsync(Guid id)
        {
            return _repository.FindAsync(id);
        }

        public virtual IEnumerable<TEntity> GetAllAsNoTracking()
        {
            return _repository.GetAllAsNoTracking();
        }

        public virtual TEntity Update(TEntity obj)
        {
            return _repository.Update(obj);
        }

        public virtual Task RemoveAsync(Guid id)
        {
            return _repository.RemoveAsync(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
