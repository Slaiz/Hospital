using System;

namespace Hospital_ClassLibrary.Model
{
    public class PatientModel
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public char BloodType { get; set; }
        public DateTime BirhtData { get; set; }
    }
}