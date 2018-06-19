using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation.Domain.Model.Entities;
using Evaluation.Domain.Model.Interfaces.Repositories;
using Evaluation.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected EvaluationContext Ctx;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(EvaluationContext context)
        {
            Ctx = context;
            DbSet = Ctx.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            var entity = await DbSet.AddAsync(obj);
            return entity.Entity;
        }

        public virtual async Task<TEntity> FindAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual IEnumerable<TEntity> GetAllAsNoTracking()
        {
            return DbSet.AsNoTracking();
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Ctx.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
        }

        public void Dispose()
        {
            Ctx.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
