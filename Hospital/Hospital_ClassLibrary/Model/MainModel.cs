using System;

namespace Hospital_ClassLibrary.Model
{
    public class MainModel
    {
        public int ExaminationID { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string Post { get; set; }
        public int Experience { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string BloodType { get; set; }
        public DateTime BirthDate { get; set; }

    }
}