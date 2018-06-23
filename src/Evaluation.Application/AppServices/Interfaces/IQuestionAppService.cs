using Evaluation.Application.ViewModels;

namespace Evaluation.Application.AppServices.Interfaces
{
    public interface IQuestionAppService :
        //IBaseInternalAppService<Question, QuestionViewModel>, 
        IBaseAppService<QuestionViewModel>
    {
    }
}