using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evaluation.Email.Wcf.DTO;
using Evaluation.Email.Wcf.EmailWcfService;

namespace Evaluation.Email.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManualEmailSender" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ManualEmailSender.svc or ManualEmailSender.svc.cs at the Solution Explorer and start debugging.
    public class ManualEmailSender : IManualEmailSender
    {
        public async Task<string> //SendByQuestionaryIdResponse> 
            SendByQuestionaryIdAsync(
                SendByQuestionaryIdRequest questionaryIdRequest)
        {
            //fake get email list from application/domain/infrastructure
            //this list comes from everyone registered to the questionary
            //var questionaryEmails = _application.GetFormattedEmailsByQuestionaryId(questionaryIdRequest.QuestionaryId);
            var emailRequests = new List<EmailRequest>
            {
                new EmailRequest
                {
                    EvaluationId = Guid.NewGuid(),
                    Recipient = "asd@asd.com",
                    Subject = "Asd asd asd",
                    Content = "Asd asd asd",
                },
                new EmailRequest
                {
                    EvaluationId = Guid.NewGuid(),
                    Recipient = "zxc@zxc.com",
                    Subject = "Zxc zxc zxc",
                    Content = "Zxc zxc zxc",
                }
            };

            var emailServiceClient = new EmailServiceClient();
            var emailResponses = await emailServiceClient.SendEmailAsync(emailRequests);
            emailServiceClient.Close();

            //log emailResponses

            //return new SendByQuestionaryIdResponse();
            var responseMessage = string.Join(",", emailResponses.Select(x => $"{x.Recipient}-{x.Status}"));
            return $"ManualEmailSender: {responseMessage}";
        }
    }
}