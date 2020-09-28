using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IBloodGroupRepository _bloodGroup;
        private IDoctorRepository _doctor;
        private IDepartmentRepository _department;
        private IAppointmentRepository _appointment;
        private IPatientRepository _patient;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBloodGroupRepository BloodGroups
            => _bloodGroup = _bloodGroup ?? new BloodGroupRepository(_context);

        public IDoctorRepository Doctors
            => _doctor = _doctor ?? new DoctorRepository(_context);

        public IDepartmentRepository Departments
            => _department = _department ?? new DepartmentRepository(_context);

        public IAppointmentRepository Appointments
            => _appointment = _appointment ?? new AppointmentRepository(_context);

        public IPatientRepository Patients
            => _patient = _patient ?? new PatientRepository(_context);

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
            => _context.Dispose();
    }
}
