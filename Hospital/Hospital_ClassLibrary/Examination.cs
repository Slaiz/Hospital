//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital_ClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Examination
    {
        public int ExaminationID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public System.DateTime DataStart { get; set; }
        public System.TimeSpan TimeStart { get; set; }
        public System.TimeSpan TimeEnd { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}