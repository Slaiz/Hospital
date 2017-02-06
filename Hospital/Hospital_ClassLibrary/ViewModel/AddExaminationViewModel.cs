using System;
using System.Diagnostics;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;
using System.Windows;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.ViewModel
{
    public class AddExaminationViewModel
    {
        public ICommand OpenDoctorTableCommand { get; set; }
        public ICommand OpenPatientTableCommand { get; set; }

        public Func<TypeView, IView> CreateViewAction { get; set; }

        public AddExaminationViewModel(Func<TypeView,IView> createViewAction)
        {
            CreateViewAction = createViewAction;
            OpenDoctorTableCommand = new MainCommand(arg => OpenDoctorTable());
            OpenPatientTableCommand = new MainCommand(arg => OpenPatientTable());
        }

        public void OpenDoctorTable()
        {
            var view = CreateViewAction(TypeView.DoctorView);
            view.ShowView();
        }

        public void OpenPatientTable()
        {
            var view = CreateViewAction(TypeView.PatientView);
            view.ShowView();
        }


    }
}