using System;
using System.Collections.Generic;
using System.Text;

namespace PollProgram.ViewModels
{
    class QuestionViewModel: BaseViewModel
    {
        public string Question { get; set; }
        public int Score { get; set; }
        public IObservable<Answer> Answers { get; set; }

        public class Answer
        {
            public string Text { get; set; }
            public bool IsChecked { get; set; }
            public int Score { get; set; }
        }
    }
}
