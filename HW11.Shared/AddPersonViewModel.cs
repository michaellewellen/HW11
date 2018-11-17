using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HW11.Types;


namespace HW11.Shared
{
    public class AddPersonViewModel : INotifyPropertyChanged
    {
        private readonly PeopleRepository repo;


        public AddPersonViewModel(PeopleRepository repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetField(ref firstName, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetField(ref lastName, value); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { SetField(ref age, value); }
        }

        private ICommand addPerson;
        public ICommand AddPerson => addPerson ?? (addPerson = new SimpleCommand(() =>
        {
            if (repo.AddPerson(new Person(FirstName,LastName, Age)))
                IsClosed = true;
        }));

        private bool isClosed;
        public bool IsClosed
        {
            get { return isClosed; }
            set { SetField(ref isClosed, value); }
        }


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
