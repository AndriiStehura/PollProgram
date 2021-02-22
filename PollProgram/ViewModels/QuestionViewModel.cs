using System;
using System.Collections.Generic;
using System.Text;
using PollProgram.Views.Controls;

namespace PollProgram.ViewModels
{
    public class QuestionViewModel: BaseViewModel
    {
        public string Question { get; set; }
        public IEnumerable<Answer> Answers { get; set; }

        public class Answer: BaseViewModel
        {
            private string _text;
            private bool _isChecked;
            private int _score;
            public string Text 
            {
                get => _text;
                set
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
            public bool IsChecked 
            {
                get => _isChecked;
                set
                {
                    _isChecked = value;
                    OnPropertyChanged();
                }
            }

            public int Score 
            {
                get => _score;
                set
                {
                    _score = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
