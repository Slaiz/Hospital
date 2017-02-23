using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using Hospital_ClassLibrary.Model;
using Hospital_ClassLibrary.Shared;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        
        public ICommand OpenDoctorTableCommand { get; set; }
        public ICommand OpenPatientTableCommand { get; set; }
        public ICommand OpenExaminationTableCommand { get; set; }
        public ICommand OpenAddExaminationViewCommand { get; set; }
        public ICommand FindCommand { get; set; }

        public DataWork DWork = new DataWork();

        public Func<object, TypeView, IView> CreateViewAction { get; set; }
        public ObservableCollection<MainModel> MainList { get; set; }
        public ObservableCollection<string> FindParametrList { get; set; }
        public NameFindParamtr FindParametr { get; set; }
        public string NameParametr { get; set; }

        public MainViewModel(Func<object, TypeView, IView> createViewAction)
        { 
            CreateViewAction = createViewAction;

            DataWork.OnUpdateMainModel +=DataWorkOnOnUpdateMainModel;

            MainList = new ObservableCollection<MainModel>(DWork.GetMainList());
            FindParametrList = new ObservableCollection<string>(DWork.GetFindParamtrList());

            OpenDoctorTableCommand = new MainCommand(arg => OpenDoctorTable());
            OpenPatientTableCommand = new MainCommand(arg => OpenPatientTable());
            OpenExaminationTableCommand = new MainCommand(arg => OpenExaminationTable());
            OpenAddExaminationViewCommand = new MainCommand(arg => OpenAddExaminationView());
            FindCommand = new MainCommand(arg => Find(FindParametr, NameParametr));
        }

        private void DataWorkOnOnUpdateMainModel(object sender, EventArgs eventArgs)
        {
            MainList.Clear();

            foreach (var item in DWork.GetMainList())
            {
                MainList.Add(item);
            }
        }

        private void Find(NameFindParamtr FindParametr, string NameParametr)
        {
            MainList.Clear();

            foreach (var item in DWork.Find(FindParametr, NameParametr))
            {
                MainList.Add(item) ;
            }
        }

        public void OpenDoctorTable()
        {
            var view = CreateViewAction(null, TypeView.DoctorView);
            view.ShowView();
        }

        public void OpenPatientTable()
        {
            var view = CreateViewAction(null, TypeView.PatientView);
            view.ShowView();
        }

        public void OpenExaminationTable()
        {
            var view = CreateViewAction(null, TypeView.ExaminationView);
            view.ShowView();
        }

        private void OpenAddExaminationView()
        {
            var view = CreateViewAction(null, TypeView.AddExaminationView);
            view.ShowView();
        }
    }
}