using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital_ClassLibrary.Model
{
    public class PatientModel
    {
        [Key]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string BloodType { get; set; }
        public DateTime BirthDate { get; set; }
    }
}