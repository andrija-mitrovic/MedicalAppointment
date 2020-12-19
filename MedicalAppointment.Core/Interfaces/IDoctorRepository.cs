using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IDoctorRepository:IGenericRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsWithDepartmentAsync();
        Task<Doctor> GetDoctorWithDepartmentByIdAsync(int id);
        Task<int> GetTotalNumberOfDoctorsAsync();
        Task<int> GetTotalNumberOfMaleDoctorAsync();
        Task<int> GetTotalNumberOfFemaleDoctorAsync();
    }
}
