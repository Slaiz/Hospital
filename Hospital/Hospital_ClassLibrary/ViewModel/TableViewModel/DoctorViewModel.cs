using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.Shared;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel.TableViewModel
{
    [ImplementPropertyChanged]
    public class DoctorViewModel:BaseViewModel
    {
        public ICommand OpenAddDoctorViewCommand { get; set; }
        public ICommand OpenEditDoctorViewCommand { get; set; }
        public ICommand DeleteDoctorCommand { get; set; }

        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        public ObservableCollection<Doctor> DoctorList { get; set; }

        public Doctor SelectedDoctor { get; set; }

        private int index;

        public DataWork DWork = new DataWork();

        public DoctorViewModel(Func<object, TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            DoctorList = new ObservableCollection<Doctor>(DWork.GetDoctorList());

            DataWork.OnAddDoctor += DWorkOnOnAddDoctor;
            DataWork.OnDeleteDoctor += DataWorkOnOnDeleteDoctor;
            DataWork.OnUpdateDoctor += DataWorkOnOnUpdateDoctor;

            OpenAddDoctorViewCommand = new MainCommand(arg => OpenAddDoctorView());
            OpenEditDoctorViewCommand = new MainCommand(arg => OpenEditDoctorView());
            DeleteDoctorCommand = new MainCommand(arg => DeleteDoctor());
        }

        private void DataWorkOnOnUpdateDoctor(Doctor newDoctor, Doctor oldDoctor)
        {
            index = DoctorList.IndexOf(oldDoctor);
            DoctorList.RemoveAt(index);
            DoctorList.Insert(index, newDoctor);
        }

        private void DataWorkOnOnDeleteDoctor(object sender, Doctor doctor)
        {
            DoctorList.Remove(doctor);
        }

        private void DWorkOnOnAddDoctor(object sender, Doctor doctor)
        {
           DoctorList.Add(doctor);
        }

        private void OpenAddDoctorView()
        {
            var view = CreateViewAction(null, TypeView.AddDoctorView);
            view.ShowView();
        }

        private void OpenEditDoctorView()
        {
            if (SelectedDoctor != null)
            {
                var view = CreateViewAction(SelectedDoctor, TypeView.EditDoctorView);
                view.ShowView();
            }
            else MessageBox.Show("Please choose doctor to edit !");
        }

        private void DeleteDoctor()
        {
            DWork.DeleteDoctor(SelectedDoctor);
            MessageBox.Show("Doctor was deleted !");
        }
    }
}