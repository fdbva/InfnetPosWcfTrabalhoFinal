using System.Net;
using System.Runtime.Serialization;

namespace AdminAuthentication.Wcf.DTO
{
    [DataContract]
    public class AddUserResponse
    {
        [DataMember] public HttpStatusCode HttpStatusCode { get; set; }

        [DataMember] public string ResponseMessage { get; set; }
    }
}