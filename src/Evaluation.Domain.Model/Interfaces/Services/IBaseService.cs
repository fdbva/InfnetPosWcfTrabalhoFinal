using Evaluation.Domain.Model.Entities;
using Evaluation.Domain.Model.Interfaces.Repositories;

namespace Evaluation.Domain.Model.Interfaces.Services
{
    public interface IBaseService<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
    }
}