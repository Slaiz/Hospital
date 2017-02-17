using System;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel.AddViewModel
{
    [ImplementPropertyChanged]
    public class AddDoctorViewModel:IDoctorViewModel
    {
        public ICommand ClearFieldsCommand { get; set; }
        public ICommand AddDoctorCommand { get; set; }

        public DataWork DWork = new DataWork();

        public string DoctorName { get; set; }

        public string DoctorSurname { get; set; }

        public string Post { get; set; }

        public int Experience { get; set; }

        public AddDoctorViewModel()
        {
            ClearFieldsCommand = new MainCommand(arg => ClearFields());
            AddDoctorCommand = new MainCommand(arg => AddDoctor());
        }

        private void ClearFields()
        {
            DoctorName = " ";
            DoctorSurname = " ";
            Post = " ";
            Experience = 0;
        }
        private void AddDoctor()
        {
            DWork.AddDoctor(DoctorName, DoctorSurname, Post, Experience);

            MessageBox.Show("Doctor was added !");
        }

    }
}