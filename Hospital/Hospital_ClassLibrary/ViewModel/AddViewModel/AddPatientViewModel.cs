﻿using System;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel.AddViewModel
{
    [ImplementPropertyChanged]
    public class AddPatientViewModel:IPatientViewModel 
    {
        public ICommand ClearFieldsCommand { get; set; }
        public ICommand AddPatientCommand { get; set; }

        public DataWork DWork = new DataWork();

        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string BloodType { get; set; }
        public DateTime BirthDate { get; set; }

        public AddPatientViewModel()
        {
            ClearFieldsCommand = new MainCommand(arg => ClearFields());
            AddPatientCommand = new MainCommand(arg => AddPatient());
        }

        private void ClearFields()
        {
            PatientName = " ";
            PatientSurname = " ";
            BloodType = " ";
        }

        private void AddPatient()
        {
            DWork.AddPatient(PatientName, PatientSurname, BloodType, BirthDate);

            MessageBox.Show("Patient was added !");
        }
    }
}