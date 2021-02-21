using PollProgram.Components;
using PollProgram.Models;
using PollProgram.Views.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PollProgram.ViewModels
{
    class StartPageViewModel
    {
        public StartPageViewModel()
        {
            Person = new PersonViewModel(new Person());
        }

        public PersonViewModel Person { get; set; }

        public ICommand ContinueCommand => new RelayCommand(obj => 
        {
            App.Current.Resources.Add("person", Person.Person);
            MainWindow mw = (MainWindow)App.Current.MainWindow;
            mw.MainFrame.Navigate(new OptionsPage());
        },
        obj => !string.IsNullOrEmpty(Person.Name));
    }
}
