using Hospital_ClassLibrary.Model;
using System.Collections.Generic;

namespace Hospital_ClassLibrary.Abstract
{
    public interface IExaminationRepository
    {
        IEnumerable<ExaminationModel> Examinations { get; }
    }
}