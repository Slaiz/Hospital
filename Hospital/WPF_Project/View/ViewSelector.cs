using Hospital_ClassLibrary;
using Hospital_ClassLibrary.Shared;
using Hospital_ClassLibrary.ViewModel;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace WPF_Project.View
{
    public static class ViewSelector
    {
        public static IView CreateViewAction(object o,TypeView typeView)
        {
            IView viewEmpty;

            switch (typeView)
            {
                case TypeView.DoctorView:
                    {
                        viewEmpty = new DoctorView();
                        break;
                    }

                case TypeView.PatientView:
                    {
                        viewEmpty = new PatientView();
                        break;
                    }
                case TypeView.ExaminationView:
                    {
                        viewEmpty = new ExaminationView();
                        break;
                    }
                case TypeView.AddExaminationView:
                    {
                        viewEmpty = new AddExminationView();
                        break;
                    }
                case TypeView.AddDoctorView:
                    {
                        viewEmpty = new AddDoctorView();
                        break;
                    }
                case TypeView.AddPatientView:
                    {
                        viewEmpty = new AddPatientView();
                        break;
                    }
                case TypeView.EditExaminationView:
                    {
                        viewEmpty = new EditExaminationView((Examination)o);
                        break;
                    }
                case TypeView.EditDoctorView:
                    {
                        viewEmpty = new EditDoctorView((Doctor)o);
                        break;
                    }
                case TypeView.EditPatientView:
                    {
                        viewEmpty = new EditPatientView((Patient)o);
                        break;
                    }
                default:
                    {
                        viewEmpty = null;
                        break;
                    }
            }

            return viewEmpty;
        }
    }
}