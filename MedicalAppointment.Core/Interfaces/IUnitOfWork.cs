using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IBloodGroupRepository BloodGroups { get; }
        IDepartmentRepository Departments { get; }
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }
        IUserRepository Users { get; }
        Task<bool> SaveAsync();
    }
}
