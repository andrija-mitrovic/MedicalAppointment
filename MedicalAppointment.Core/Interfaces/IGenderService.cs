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
        Task<decimal> GetPercentOfMalePatientGender();
        Task<decimal> GetPercentOfFemalePatientGender();
        Task<int> GetMaleDoctorsNumber();
        Task<int> GetFemaleDoctorsNumber();
        Task<decimal> GetPercentOfMaleDoctorGender();
        Task<decimal> GetPercentOfFemaleDoctorGender();
    }
}
