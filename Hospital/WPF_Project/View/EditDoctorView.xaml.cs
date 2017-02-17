using System.Windows;
using Hospital_ClassLibrary;
using Hospital_ClassLibrary.ViewModel.EditViewModel;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for EditDoctorView.xaml
    /// </summary>
    public partial class EditDoctorView : Window, IView
    {
        private readonly EditDoctorViewModel editDoctorViewModel;

        public EditDoctorView(Doctor item)
        {
            editDoctorViewModel = new EditDoctorViewModel(item);

            DataContext = editDoctorViewModel;

            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}
