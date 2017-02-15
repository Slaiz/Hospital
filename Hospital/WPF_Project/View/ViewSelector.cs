using Hospital_ClassLibrary.ViewModel;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace WPF_Project.View
{
    public static class ViewSelector
    {
        public static IView CreateViewAction(TypeView typeView)
        {
            IView view;

            switch (typeView)
            {
                case TypeView.DoctorView:
                    {
                        view = new DoctorView();
                        break;
                    }

                case TypeView.PatientView:
                    {
                        view = new PatientView();
                        break;
                    }
                case TypeView.ExaminationView:
                    {
                        view = new ExaminationView();
                        break;
                    }
                case TypeView.AddExaminationView:
                    {
                        view = new AddExminationView();
                        break;
                    }
                default:
                    {
                        view = null;
                        break;
                    }
            }

            return view;
        }
    }
}