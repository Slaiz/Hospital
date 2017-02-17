using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital_ClassLibrary.ViewModel;
using Hospital_ClassLibrary.ViewModel.AddViewModel;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AddPatientView.xaml
    /// </summary>
    public partial class AddPatientView : Window,IView
    {
        private readonly AddPatientViewModel addPatientViewModel;
        public AddPatientView()
        {
            addPatientViewModel = new AddPatientViewModel();;
            DataContext = addPatientViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}
