using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Evaluation.Application.ViewModels
{
    [DataContract]
    public class BaseViewModel
    {
        [Key] [DataMember] public Guid Id { get; set; }
    }
}