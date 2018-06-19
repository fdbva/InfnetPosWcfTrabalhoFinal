using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation.Domain.Model.Entities;

namespace Evaluation.Domain.Model.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> FindAsync(Guid id);
        IEnumerable<TEntity> GetAllAsNoTracking();
        TEntity Update(TEntity obj);
        Task RemoveAsync(Guid id);
        void Remove(TEntity obj);
        void Dispose();
    }
}
