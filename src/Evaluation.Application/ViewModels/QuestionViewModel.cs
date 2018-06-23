using System.Runtime.Serialization;

namespace Evaluation.Application.ViewModels
{
    [DataContract]
    public class QuestionViewModel : BaseViewModel
    {
        [DataMember] public string Text { get; set; }
    }
}