using System;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Windows.Input;
using Hospital_ClassLibrary.Model;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.ViewModel
{
    public class DoctorViewModel
    {
        public ICommand OpenAddDoctorViewCommand { get; set; }
        public Func<TypeView, IView> CreateViewAction { get; set; }
        public ObservableCollection<Doctor> DoctorList { get; set; }

        public DataWork DWork = new DataWork();
        public DoctorViewModel(Func<TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            DoctorList = new ObservableCollection<Doctor>(DWork.GetDoctorList());

            OpenAddDoctorViewCommand = new MainCommand(arg => OpenAddDoctorView());
        }

        private void OpenAddDoctorView()
        {
            var view = CreateViewAction(TypeView.AddDoctorView);
            view.ShowView();
        }
    }
}