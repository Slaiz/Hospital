using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
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

            ExaminationList = new ObservableCollection<Examination>(DWork.GetExaminationList());

            OpenAddExaminationViewCommand = new MainCommand(arg => OpenAddExaminationView());
            OpenEditExaminationViewCommand = new MainCommand(arg => OpenEditExaminationView());
            DeleteExaminationCommand = new MainCommand(arg => DeleteExamination());
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