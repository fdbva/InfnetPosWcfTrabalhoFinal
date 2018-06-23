using System;
using System.Net;
using System.Runtime.Serialization;

namespace Email.Wcf.DTO
{
    [DataContract]
    public class EmailResponse
    {
        [DataMember] public Guid EvaluationId { get; set; }

        [DataMember] public string Recipient { get; set; }

        [DataMember] public HttpStatusCode HttpStatusCode { get; set; }

        [DataMember] public string ResponseMessage { get; set; }
    }
}