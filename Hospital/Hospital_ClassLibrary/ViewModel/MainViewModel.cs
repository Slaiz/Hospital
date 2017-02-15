﻿using System;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.ViewModel
{
    public class MainViewModel
    {
        public ICommand OpenDoctorTableCommand { get; set; }
        public ICommand OpenPatientTableCommand { get; set; }
        public ICommand OpenExaminationTableCommand { get; set; }
        public ICommand OpenAddExaminationViewCommand { get; set; }

        public Func<TypeView, IView> CreateViewAction { get; set; }

        public MainViewModel(Func<TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            OpenDoctorTableCommand = new MainCommand(arg => OpenDoctorTable());
            OpenPatientTableCommand = new MainCommand(arg => OpenPatientTable());
            OpenExaminationTableCommand = new MainCommand(arg => OpenExaminationTable());
            OpenAddExaminationViewCommand = new MainCommand(arg => OpenAddExaminationView());
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

        public void OpenExaminationTable()
        {
            var view = CreateViewAction(TypeView.ExaminationView);
            view.ShowView();
        }

        private void OpenAddExaminationView()
        {
            var view = CreateViewAction(TypeView.AddExaminationView);
            view.ShowView();
        }
    }
}