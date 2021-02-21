using PollProgram.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PollProgram.ViewModels
{
    class PersonViewModel: BaseViewModel
    {
        private Person _person;

        public PersonViewModel(Person person)
        {
            _person = person;
        }

        public string Name 
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                OnPropertyChanged();
            }
        }

        public Person Person => _person;
    }
}
