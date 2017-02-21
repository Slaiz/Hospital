using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital_ClassLibrary.Model
{
    public class ExaminationModel
    {
        [Key]
        public int ExaminationId { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}