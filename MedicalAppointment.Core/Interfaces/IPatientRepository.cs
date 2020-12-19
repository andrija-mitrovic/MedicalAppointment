using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IPatientRepository:IGenericRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetPatientWithBloodGroupAsync();
        Task<Patient> GetPatientWithBloodGroupByIdAsync(int id);
        Task<int> GetTotalNumberOfMalePatientAsync();
        Task<int> GetTotalNumberOfFemalePatientAsync();
        Task<int> GetTotalNumberOfPatientsAsync();
        List<PatientsNumberByYears> GetPatientsNumberByAgeAsync();
    }
}
