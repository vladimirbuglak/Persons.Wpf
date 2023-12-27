using System.Linq;
using Persons.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Persons.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new PersonViewModel();
        }
    }
}
