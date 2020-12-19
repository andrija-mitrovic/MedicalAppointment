using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IAppointmentRepository:IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsWithPatientDoctorDepartmentAsync();
        Task<Appointment> GetAppointmentWithPatientDoctorDepartmentByIdAsync(int id);
        Task<int> GetTotalNumberOfAppointmentsAsync();
    }
}
