using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation.Application.ViewModels;
using Evaluation.Domain.Model.Entities;

namespace Evaluation.Application.AppServices.Interfaces
{
    public interface IBaseInternalAppService<TEntity, TEntityViewModel>
        where TEntity : BaseEntity
        where TEntityViewModel : BaseViewModel
    {
        Task<TEntityViewModel> AddAsync(TEntityViewModel obj);
        Task<TEntityViewModel> FindAsync(Guid id);
        IEnumerable<TEntityViewModel> GetAllAsNoTracking();
        IEnumerable<TEntityViewModel> GetAll();
        TEntityViewModel Update(TEntityViewModel obj);
        Task RemoveAsync(Guid id);
        void Remove(TEntityViewModel obj);
        void Dispose();
    }
}
