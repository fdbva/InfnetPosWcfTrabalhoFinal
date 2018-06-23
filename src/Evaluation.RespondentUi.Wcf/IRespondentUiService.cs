using System.ServiceModel;
using System.Threading.Tasks;
using Evaluation.Application.ViewModels;

namespace Evaluation.RespondentUi.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRespondentUiService" in both code and config file together.
    [ServiceContract]
    public interface IRespondentUiService
    {
        [OperationContract]
        Task<QuestionViewModel> AddAsync(QuestionViewModel obj);

        [OperationContract]
        Task<QuestionViewModel> AddWithoutCommitAsync(QuestionViewModel obj);

        [OperationContract]
        Task CommitAsync();
    }
}