using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IGenderService
    {
        Task<int> GetMalePatientNumber();
        Task<int> GetFemalePatientNumber();
        Task<decimal> GetPercentOfMaleGender();
        Task<decimal> GetPercentOfFemaleGender();
    }
}
