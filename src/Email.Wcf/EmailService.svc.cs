using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Email.Wcf.DTO;

namespace Email.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmailService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmailService.svc or EmailService.svc.cs at the Solution Explorer and start debugging.
    public class EmailService : IEmailService
    {
        public async Task<List<EmailResponse>> SendEmail(List<EmailRequest> emailRequests)
        {
            //send email logic (await here, async)

            //email logic saves log -> retry possibility and reports

            //fake response
            var emailResponses = new List<EmailResponse>();
            foreach (var emailRequest in emailRequests)
            {
                emailResponses.Add(new EmailResponse
                {
                    EvaluationId = emailRequest.EvaluationId,
                    Recipient = emailRequest.Recipient,
                    HttpStatusCode = HttpStatusCode.OK,
                    ResponseMessage = "Success!"
                });
            }

            return emailResponses;
        }
    }
}