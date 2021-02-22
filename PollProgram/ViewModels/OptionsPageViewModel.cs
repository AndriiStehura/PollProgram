using PollProgram.Components;
using PollProgram.Views.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PollProgram.ViewModels
{
    class OptionsPageViewModel: BaseViewModel
    {
        public ICommand PollCommand => new RelayCommand(obj =>
        {
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.MainFrame.Navigate(new PollPage());
        });
    }
}
