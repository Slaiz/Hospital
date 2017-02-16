using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.ViewModel
{
    public class PatientViewModel
    {
        public ICommand OpenAddPatientViewCommand { get; set; }
        public Func<TypeView, IView> CreateViewAction { get; set; }
        public ObservableCollection<Patient> PatientList { get; set; }

        public DataWork DWork = new DataWork();

        public PatientViewModel(Func<TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            PatientList = new ObservableCollection<Patient>(DWork.GetPatientList());

            OpenAddPatientViewCommand = new MainCommand(arg => OpenAddPatientView());
        }

        private void OpenAddPatientView()
        {
            var view = CreateViewAction(TypeView.AddPatientView);
            view.ShowView();
        }
    }
}