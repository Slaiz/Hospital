using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.ViewModel
{
    public class ExaminationViewModel
    {
        public ICommand OpenAddExaminationViewCommand { get; set; }
        public Func<TypeView, IView> CreateViewAction { get; set; }
        public ObservableCollection<Examination> ExaminationList { get; set; }

        public DataWork DWork = new DataWork();

        public ExaminationViewModel(Func<TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            ExaminationList = new ObservableCollection<Examination>(DWork.GetExaminationList());

            OpenAddExaminationViewCommand = new MainCommand(arg => OpenAddExaminationView());
        }

        private void OpenAddExaminationView()
        {
            var view = CreateViewAction(TypeView.AddExaminationView);
            view.ShowView();
        }
    }
}