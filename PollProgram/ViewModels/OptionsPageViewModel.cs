using PollProgram.Components;
using PollProgram.Models;
using PollProgram.Views.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PollProgram.ViewModels
{
    class OptionsPageViewModel: BaseViewModel
    {
        private readonly bool _hasPersonResult;
        private readonly UnitOfWork _unit;
        public OptionsPageViewModel()
        {
            Person person = (Person)App.Current.Resources["person"];
            _unit = new UnitOfWork();
            _hasPersonResult = _unit.ResultsRepository.HasPersonResult(person.Name);
        }

        public ICommand PollCommand => new RelayCommand(obj =>
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.MainFrame.Navigate(new PollPage());
        });

        public ICommand ResultsCommand => new RelayCommand(obj =>
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.MainFrame.Navigate(new ResultPage());
        }, obj => _hasPersonResult);
    }
}
