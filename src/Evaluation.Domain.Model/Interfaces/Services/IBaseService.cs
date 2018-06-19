using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation.Domain.Model.Entities;
using Evaluation.Domain.Model.Interfaces.Repositories;

namespace Evaluation.Domain.Model.Interfaces.Services
{
    public interface IBaseService<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        
    }
}
