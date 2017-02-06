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
    /// Interaction logic for ExaminationView.xaml
    /// </summary>
    public partial class ExaminationView : Window, IView
    {
        private readonly ExaminationViewModel examinationViewModel;
        public ExaminationView()
        {
            examinationViewModel = new ExaminationViewModel();
            DataContext = examinationViewModel;
            InitializeComponent();
        }

        public void ShowView()
        {
            var view = new ExaminationView();
            view.Show();
        }
    }
}
