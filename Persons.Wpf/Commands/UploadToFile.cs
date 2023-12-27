using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows.Input;
using CsvHelper;
using Persons.Wpf.Models;

namespace Persons.Wpf.Commands;

public class UploadToFile : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var persons = (ObservableCollection<Person>)parameter;

        using var writer = new StreamWriter($"Persons-{(DateTime.Now.ToString("s").Replace(":", "-"))}.csv");
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords((IEnumerable)persons);
        }
    }

    public event EventHandler? CanExecuteChanged;
}