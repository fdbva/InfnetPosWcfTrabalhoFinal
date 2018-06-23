using System.Net;
using System.ServiceModel;
using AdminAuthentication.Wcf.DTO;

namespace AdminAuthentication.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminUserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminUserService.svc or AdminUserService.svc.cs at the Solution Explorer and start debugging.
    public class AdminUserService : IAdminUserService
    {
        public AddUserResponse AddUser(AddUserRequest addUserRequest)
        {
            if (addUserRequest.Password.Length > 4)
            {
                return new AddUserResponse
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    ResponseMessage = "AdminUserService.AddUser Success!"
                };
            }

            var addUserInvalidFieldFault = new AddUserInvalidFieldFault
            {
                HttpStatusCode = HttpStatusCode.OK,
                Description = "AdminUserService.AddUser Custom Exception: Password is too small",
                Message = "Exception message if it was one"
            };
            throw new FaultException<AddUserInvalidFieldFault>(addUserInvalidFieldFault);
        }
    }
}