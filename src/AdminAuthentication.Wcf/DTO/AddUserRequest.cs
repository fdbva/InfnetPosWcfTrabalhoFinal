using System.Runtime.Serialization;

namespace AdminAuthentication.Wcf.DTO
{
    [DataContract]
    public class AddUserRequest
    {
        [DataMember] public string Email { get; set; }

        [DataMember] public string Password { get; set; }

        [DataMember] public string FirstName { get; set; }

        [DataMember] public string LastName { get; set; }
    }
}