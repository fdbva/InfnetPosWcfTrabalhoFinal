using System.ServiceModel;
using System.Threading.Tasks;
using Evaluation.Email.Wcf.DTO;

namespace Evaluation.Email.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManualEmailSender" in both code and config file together.
    [ServiceContract]
    public interface IManualEmailSender
    {
        [OperationContract]
        Task<string> //SendByQuestionaryIdResponse> 
            SendByQuestionaryIdAsync(SendByQuestionaryIdRequest questionaryIdRequest);
    }
}