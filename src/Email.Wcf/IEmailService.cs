using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Email.Wcf.DTO;

namespace Email.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmailService" in both code and config file together.
    [ServiceContract]
    public interface IEmailService
    {
        [OperationContract]
        Task<List<EmailResponse>> SendEmail(List<EmailRequest> emailRequests);
    }
}