using System.Collections.Generic;
using Hospital_ClassLibrary.Abstract;
using Hospital_ClassLibrary.Model;

namespace Hospital_ClassLibrary.Concrate
{
    public class EFExaminationRepository:IExaminationRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<ExaminationModel> Examinations
        {
            get { return context.Examinations; }
        }
    }
}