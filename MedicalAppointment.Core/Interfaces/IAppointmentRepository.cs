using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IAppointmentRepository:IGenericRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsWithPatientDoctorDepartment();
        Task<Appointment> GetAppointmentWithPatientDoctorDepartmentById(int id);
        Task<int> GetTotalNumberOfAppointments();
    }
}
