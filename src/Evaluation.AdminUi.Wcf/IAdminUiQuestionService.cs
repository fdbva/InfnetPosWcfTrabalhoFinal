using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Evaluation.Application.ViewModels;

namespace Evaluation.AdminUi.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminUiQuestionService" in both code and config file together.
    [ServiceContract]
    public interface IAdminUiQuestionService
    {
        [OperationContract]
        Task<QuestionViewModel> AddAsync(QuestionViewModel obj);

        [OperationContract]
        Task<QuestionViewModel> FindAsync(Guid id);

        [OperationContract]
        IEnumerable<QuestionViewModel> GetAllAsNoTracking();

        [OperationContract]
        IEnumerable<QuestionViewModel> GetAll();

        [OperationContract]
        QuestionViewModel Update(QuestionViewModel obj);

        [OperationContract]
        Task RemoveAsync(Guid id);
    }
}