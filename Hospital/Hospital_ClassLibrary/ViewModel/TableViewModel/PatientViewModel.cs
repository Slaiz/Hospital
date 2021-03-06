﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.Shared;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.ViewModel.TableViewModel
{
    public class PatientViewModel
    {
        public ICommand OpenAddPatientViewCommand { get; set; }
        public ICommand OpenEditPatientViewCommand { get; set; }
        public ICommand DeletePatientCommand { get; set; }

        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        public ObservableCollection<Patient> PatientList { get; set; }

        public Patient SelectedPatient { get; set; }

        public DataWork DWork = new DataWork();

        public PatientViewModel(Func<object, TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            DataWork.OnAddPatient += DataWorkOnOnAddPatient;
            DataWork.OnDeletePatient += DataWorkOnOnDeletePatient;
            DataWork.OnUpdatePatient += DataWorkOnOnUpdatePatient;

            PatientList = new ObservableCollection<Patient>(DWork.GetPatientList());

            OpenAddPatientViewCommand = new MainCommand(arg => OpenAddPatientView());
            OpenEditPatientViewCommand = new MainCommand(arg => OpenEditPatientView());
            DeletePatientCommand = new MainCommand(arg => DeletePatient());
        }

        private void DataWorkOnOnUpdatePatient(Patient newPatient, Patient oldPatient)
        {
            var patient = PatientList.First( x => x.PatientID == oldPatient.PatientID);

            var index = PatientList.IndexOf(patient);
            PatientList.RemoveAt(index);
            PatientList.Insert(index, patient);
        }

        private void DataWorkOnOnDeletePatient(object sender, Patient patient)
        {
            PatientList.Remove(patient);
        }

        private void DataWorkOnOnAddPatient(object sender, Patient patient)
        {
            PatientList.Add(patient);
        }

        private void OpenAddPatientView()
        {
            var view = CreateViewAction(null, TypeView.AddPatientView);
            view.ShowView();
        }

        private void OpenEditPatientView()
        {
            if (SelectedPatient != null)
            {
                var view = CreateViewAction(SelectedPatient, TypeView.EditPatientView);
                view.ShowView();
            }
            else MessageBox.Show("Please choose patient to edit !");
        }

        private void DeletePatient()
        {
            DWork.DeletePatient(SelectedPatient);
            MessageBox.Show("Patient was deleted !");
        }
    }
}