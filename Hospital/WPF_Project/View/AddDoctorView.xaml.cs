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
using Hospital_ClassLibrary.ViewModel.Interface;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AddDoctorView.xaml
    /// </summary>
    public partial class AddDoctorView : Window, IView
    {
        private readonly AddDoctorViewModel addDoctorViewModel;
        public AddDoctorView()
        {
            addDoctorViewModel = new AddDoctorViewModel();

            DataContext = addDoctorViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}
