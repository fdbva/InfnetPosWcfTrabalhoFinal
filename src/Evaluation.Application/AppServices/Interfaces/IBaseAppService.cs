using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evaluation.Application.ViewModels;

namespace Evaluation.Application.AppServices.Interfaces
{
    public interface IBaseAppService<TEntityViewModel>
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