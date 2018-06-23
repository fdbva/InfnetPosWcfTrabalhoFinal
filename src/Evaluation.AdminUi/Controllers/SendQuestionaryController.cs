using System;
using System.Threading.Tasks;
using ManualEmailSenderWcfService;
using Microsoft.AspNetCore.Mvc;

namespace Evaluation.AdminUi.Controllers
{
    public class SendQuestionaryController : Controller
    {
        public virtual async Task<string> ManuallySendQuestionaryById()
        {
            try
            {
                var manualEmailSenderClient = new ManualEmailSenderClient();
                var sendByQuestionaryIdRequest = new SendByQuestionaryIdRequest();

                var result = await manualEmailSenderClient.SendByQuestionaryIdAsync(sendByQuestionaryIdRequest);
                await manualEmailSenderClient.CloseAsync();

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}