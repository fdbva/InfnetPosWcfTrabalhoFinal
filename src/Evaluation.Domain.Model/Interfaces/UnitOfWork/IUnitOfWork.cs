using System.Threading.Tasks;

namespace Evaluation.Domain.Model.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task CommitAsync();
        void Commit();
    }
}