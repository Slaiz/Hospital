using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows;
using Hospital_ClassLibrary.ViewModel;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for DoctorView.xaml
    /// </summary>
    public partial class DoctorView : Window
    {
        private readonly DoctorViewModel doctorViewModel;
        public DoctorView()
        {
            doctorViewModel = new DoctorViewModel();
            DataContext = doctorViewModel;

            InitializeComponent();
        }
    }
}
