using HW11.Shared.ViewModel;
using HW11.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace HW11
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly IDataStore dataStore;

        public MainPageViewModel(IDataStore dataStore)
        {
            this.dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            People = new ObservableCollection<Person>(DataStore.GetAllPeople());
        }

        public IDataStore DataStore => dataStore;

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

        private Command addPersonCommand;
        public Command AddPersonCommand => addPersonCommand ?? (addPersonCommand = new Command(
            () =>
            {
                DataStore.AddPerson(new Person(
                    FirstName,
                    LastName,
                    Age));

                People.Clear();
                foreach (var c in DataStore.GetAllPeople())
                    People.Add(c);
                FirstName = null;
            }));

        public ObservableCollection<Person> People { get; private set; }

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