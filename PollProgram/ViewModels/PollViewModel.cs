using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PollProgram.Components;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Linq;
using System.Windows;
using PollProgram.Models;

namespace PollProgram.ViewModels
{
    class PollViewModel : BaseViewModel
    {
        private List<QuestionBlockViewModel> _pollBlocks;
        private UnitOfWork _unit;
        private Person _person;

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

            _person = (Person)App.Current.Resources["person"];
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

        public ICommand ClearAllCommand => new RelayCommand(obj =>
        {
            foreach (var block in _pollBlocks)
                foreach (var question in block.Questions)
                    foreach (var answer in question.Answers)
                        answer.IsChecked = false;
        });

        public ICommand BackCommand => new RelayCommand(obj =>
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.MainFrame.GoBack();
        });

        public ICommand CompleteCommand => new RelayCommand(obj =>
        {
            foreach(var block in _pollBlocks)
                foreach(var question in block.Questions)
                {
                    if (!question.Answers.Any(x => x.IsChecked))
                    {
                        MessageBox.Show("Ви відповіли не на всі запитання. Поверніться та дайте відповдь на питання, що залишились.",
                            "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

            //save into json
            _unit.ResultsRepository.FilePath = _person.Name + ".json";
            var results = _pollBlocks.Select(x => new
            {
                Name = x.Name,
                Answers = x.Questions
                    .SelectMany(y => y.Answers)
                    .Where(y => y.IsChecked)
                    .Select(y => y.Score)
                    .ToArray()
            });
            _unit.ResultsRepository.SaveAsJson(results);

            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.MainFrame.Navigate(new Views.Pages.ResultPage());
        });
    }
}
