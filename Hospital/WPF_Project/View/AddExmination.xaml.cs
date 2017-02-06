using Hospital_ClassLibrary.ViewModel;
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
using Hospital_ClassLibrary.ViewModel.Interface;

namespace WPF_Project.View
{
    /// <summary>
    /// Interaction logic for AddExmination.xaml
    /// </summary>
    public partial class AddExmination : Window
    {
        private readonly AddExaminationViewModel addExaminationViewModel;
        public AddExmination()
        {
            addExaminationViewModel = new AddExaminationViewModel(ViewSelector.CreateViewAction);

            DataContext = addExaminationViewModel;
            InitializeComponent();
        }

    }
}
