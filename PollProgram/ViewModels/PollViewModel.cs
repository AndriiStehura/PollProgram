using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PollProgram.Components;
using Newtonsoft.Json;

namespace PollProgram.ViewModels
{
    class PollViewModel: BaseViewModel
    {
        private List<QuestionBlockViewModel> _pollBlocks;
        private UnitOfWork _unit;

        public PollViewModel()
        {
            _unit = new UnitOfWork();
            _pollBlocks = new List<QuestionBlockViewModel>();
            
            string[] levels = new string[]
            {
                "novice", "advanced", "competent", "proficient", "expert"  
            };
            foreach (string level in levels)
            {
                _unit.PollQuestions.FilePath = $"{Environment.CurrentDirectory}/Resources/Questions/{level}.json";
                _pollBlocks.Add(_unit.PollQuestions.GetBlock());
            }
        }

        public List<QuestionBlockViewModel> PollBlocks 
        {
            get => _pollBlocks;
            set
            {
                _pollBlocks = value;
                OnPropertyChanged();
            }
        }
    }
}
