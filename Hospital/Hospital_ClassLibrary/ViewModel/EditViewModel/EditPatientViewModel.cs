﻿using System;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.Shared;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel.EditViewModel
{
    [ImplementPropertyChanged]
    public class EditPatientViewModel:IPatientViewModel
    {
        public ICommand ClearFieldsCommand { get; set; }
        public ICommand EditPatientCommand { get; set; }

        public DataWork DWork = new DataWork();

        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string BloodType { get; set; }
        public DateTime BirthDate { get; set; }

        public EditPatientViewModel(Patient selectedItem)
        {
            BirthDate = new DateTime(1930, 1, 1);

            PatientName = selectedItem.PatientName;
            PatientSurname = selectedItem.PatientSurname;
            BloodType = selectedItem.BloodType;
            BirthDate = selectedItem.BirthDate;

            ClearFieldsCommand = new MainCommand(arg => ClearFields());
            EditPatientCommand = new MainCommand(arg => EditPatient(selectedItem));
        }

        private void ClearFields()
        {
            PatientName = " ";
            PatientSurname = " ";
            BloodType = " ";
        }

        private void EditPatient(Patient selectedItem)
        {
            DWork.AddPatient(PatientName, PatientSurname, BloodType, BirthDate);

            MessageBox.Show("Patient was updated !");
        }
    }
}