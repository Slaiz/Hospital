using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital_ClassLibrary.Model
{
    public class ExaminationModel
    {
        [Key]
        public int ExaminationID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime DataStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}