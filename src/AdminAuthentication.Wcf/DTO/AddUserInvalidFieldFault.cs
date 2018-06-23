using System.Net;
using System.Runtime.Serialization;

namespace AdminAuthentication.Wcf.DTO
{
    [DataContract]
    public class AddUserInvalidFieldFault
    {
        [DataMember] public HttpStatusCode HttpStatusCode { get; set; }

        [DataMember] public string Message { get; set; }

        [DataMember] public string Description { get; set; }
    }
}