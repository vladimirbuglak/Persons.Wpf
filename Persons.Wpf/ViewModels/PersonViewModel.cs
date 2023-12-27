using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using CsvHelper;
using Persons.Wpf.Commands;
using Persons.Wpf.Models;

namespace Persons.Wpf.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person selected;

        public Person Selected
        {
            get => selected;
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        public UploadToFile UploadToFileCommand { get; set; }

        public ObservableCollection<Person> Persons { get; set; }
        

        public event PropertyChangedEventHandler? PropertyChanged;

        public PersonViewModel()
        {
            using var reader = new StreamReader("Persons.csv");
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Persons = new ObservableCollection<Person>(csv.GetRecords<Person>());
            }

            UploadToFileCommand = new UploadToFile();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
