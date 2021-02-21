using System;
using System.Collections.Generic;
using System.Text;

namespace PollProgram.ViewModels
{
    class QuestionBlockViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public IObservable<QuestionViewModel> Questions { get; set; }
    }
}
