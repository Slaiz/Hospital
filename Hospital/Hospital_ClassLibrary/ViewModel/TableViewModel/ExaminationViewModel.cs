using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.Shared;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.ViewModel.TableViewModel
{
    public class ExaminationViewModel
    {
        public ICommand OpenAddExaminationViewCommand { get; set; }
        public ICommand OpenEditExaminationViewCommand { get; set; }
        public ICommand DeleteExaminationCommand { get; set; } 

        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        public ObservableCollection<Examination> ExaminationList { get; set; }

        public Examination SelectedExamination { get; set; }

        public DataWork DWork = new DataWork();

        public ExaminationViewModel(Func<object, TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            DataWork.OnAddExamination += DataWorkOnOnAddExamination;
            DataWork.OnDeleteExamination += DataWorkOnOnDeleteExamination;
            DataWork.OnUpdateExamination += DataWorkOnOnUpdateExamination;

            ExaminationList = new ObservableCollection<Examination>(DWork.GetExaminationList());

            OpenAddExaminationViewCommand = new MainCommand(arg => OpenAddExaminationView());
            OpenEditExaminationViewCommand = new MainCommand(arg => OpenEditExaminationView());
            DeleteExaminationCommand = new MainCommand(arg => DeleteExamination());
        }

        private void DataWorkOnOnUpdateExamination(Examination newExamination, Examination oldExamination)
        {
            var doctor = ExaminationList.First(x => x.ExaminationID == oldExamination.DoctorID);

            var index = ExaminationList.IndexOf(doctor);
            ExaminationList.RemoveAt(index);
            ExaminationList.Insert(index, newExamination);
        }

        private void DataWorkOnOnDeleteExamination(object sender, Examination examination)
        {
            ExaminationList.Remove(examination);
        }

        private void DataWorkOnOnAddExamination(object sender, Examination examination)
        {
            ExaminationList.Add(examination);
        }

        private void OpenAddExaminationView()
        {
            var view = CreateViewAction(null, TypeView.AddExaminationView);
            view.ShowView();
        }

        private void OpenEditExaminationView()
        { 
            if (SelectedExamination != null)
            {
                var view = CreateViewAction(SelectedExamination, TypeView.EditExaminationView);
                view.ShowView();
            }
            else MessageBox.Show("Please choose examination to edit !");
        }

        private void DeleteExamination()
        {
            DWork.DeleteExamination(SelectedExamination);
            MessageBox.Show("Examination was deleted !");
        }
    }
}