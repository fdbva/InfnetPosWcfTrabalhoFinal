using System;
using System.ServiceModel;
using System.Threading.Tasks;
using AdminUserWcfService;
using Microsoft.AspNetCore.Mvc;

namespace Evaluation.AdminUi.Controllers
{
    public class AdminUserController : Controller
    {
        public virtual async Task<string> AddUserSuccess()
        {
            var adminUserServiceClient = new AdminUserServiceClient();
            try
            {
                var addUserRequest = new AddUserRequest
                {
                    Email = "asd@asd.com",
                    FirstName = "Asd",
                    LastName = "Asd",
                    Password = "12345"
                };
                var addUserResponse = await adminUserServiceClient.AddUserAsync(addUserRequest);
                await adminUserServiceClient.CloseAsync();
                return addUserResponse.ResponseMessage;
            }
            catch (FaultException<AddUserInvalidFieldFault> faultException)
            {
                adminUserServiceClient.Abort();
                return faultException.Detail.Description;
            }
            catch (Exception e)
            {
                adminUserServiceClient.Abort();
                Console.WriteLine(e);
                throw;
            }
        }

        public virtual async Task<string> AddUserCustomFaultException()
        {
            var adminUserServiceClient = new AdminUserServiceClient();
            try
            {
                var addUserRequest = new AddUserRequest
                {
                    Email = "asd@asd.com",
                    FirstName = "Asd",
                    LastName = "Asd",
                    Password = "123"
                };
                var addUserResponse = await adminUserServiceClient.AddUserAsync(addUserRequest);
                await adminUserServiceClient.CloseAsync();
                return addUserResponse.ResponseMessage;
            }
            catch (FaultException<AddUserInvalidFieldFault> faultException)
            {
                adminUserServiceClient.Abort();
                return faultException.Detail.Description;
            }
            catch (Exception e)
            {
                adminUserServiceClient.Abort();
                Console.WriteLine(e);
                throw;
            }
        }
    }
}