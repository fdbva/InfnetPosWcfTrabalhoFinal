using System;
using System.Runtime.Serialization;

namespace Email.Wcf.DTO
{
    [DataContract]
    public class EmailRequest
    {
        [DataMember] public Guid EvaluationId { get; set; }

        [DataMember] public string Recipient { get; set; }

        [DataMember] public string Subject { get; set; }

        [DataMember] public string Content { get; set; }
    }
}