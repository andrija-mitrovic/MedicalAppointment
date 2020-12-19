using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IGenderService
    {
        Task<int> GetMalePatientNumberAsync();
        Task<int> GetFemalePatientNumberAsync();
        Task<decimal> GetPercentOfMalePatientGenderAsync();
        Task<decimal> GetPercentOfFemalePatientGenderAsync();
        Task<int> GetMaleDoctorsNumberAsync();
        Task<int> GetFemaleDoctorsNumberAsync();
        Task<decimal> GetPercentOfMaleDoctorGenderAsync();
        Task<decimal> GetPercentOfFemaleDoctorGenderAsync();
    }
}
