using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using Hospital_ClassLibrary.Model;

namespace Hospital_ClassLibrary.ViewModel
{
    public class DoctorViewModel
    {
        public DoctorViewModel()
        {

            HospitalEntities entities = new HospitalEntities();

            DoctorList = new ObservableCollection<Doctor>(entities.Doctors.ToList());
        }

        public ObservableCollection<Doctor> DoctorList { get; set; }
    }
}