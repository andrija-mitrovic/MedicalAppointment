using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IDoctorRepository:IGenericRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsWithDepartment();
        Task<Doctor> GetDoctorWithDepartmentById(int id);
        Task<int> GetTotalNumberOfDoctors();
    }
}
