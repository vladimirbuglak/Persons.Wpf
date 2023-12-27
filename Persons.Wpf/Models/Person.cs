using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Persons.Wpf.Models
{
    public class Person : INotifyPropertyChanged
    {
        private int id;

        public int Id { get => id; set { id = value; OnPropertyChanged(); } }

        private string firstName;

        public string FirstName { get => firstName; set { firstName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); } }

        private string lastName;
        public string LastName { get => lastName; set { lastName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); } }

        public string FullName => $"{FirstName} {LastName}";

        private string email;

        public string Email { get => email; set { email = value; OnPropertyChanged(); } }

        private string city;

        public string City { get => city; set { city = value; OnPropertyChanged(); } }

        private string phone;

        public string Phone { get => phone; set { phone = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
