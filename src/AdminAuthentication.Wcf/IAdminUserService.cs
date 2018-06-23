using System.ServiceModel;
using AdminAuthentication.Wcf.DTO;

namespace AdminAuthentication.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminUserService" in both code and config file together.
    [ServiceContract]
    public interface IAdminUserService
    {
        [OperationContract]
        [FaultContract(typeof(AddUserInvalidFieldFault))]
        AddUserResponse AddUser(AddUserRequest addUserRequest);
    }
}