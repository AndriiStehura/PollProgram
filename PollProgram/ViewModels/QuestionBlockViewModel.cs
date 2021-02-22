using System;
using System.Collections.Generic;
using System.Text;

namespace PollProgram.ViewModels
{
    public class QuestionBlockViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
    }
}
