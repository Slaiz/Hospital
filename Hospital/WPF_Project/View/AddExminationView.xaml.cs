using System.Windows;
using Hospital_ClassLibrary.ViewModel;
using Hospital_ClassLibrary.ViewModel.AddViewModel;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AddExminationView.xaml
    /// </summary>
    public partial class AddExminationView : Window,IView
    {
        private readonly AddExaminationViewModel addExaminationViewModel;
        public AddExminationView()
        {
            addExaminationViewModel = new AddExaminationViewModel(ViewSelector.CreateViewAction);

            DataContext = addExaminationViewModel;
            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }
    }
}
