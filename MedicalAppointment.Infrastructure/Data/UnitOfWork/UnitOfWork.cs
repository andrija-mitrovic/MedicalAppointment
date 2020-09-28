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

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBloodGroupRepository BloodGroup
            => _bloodGroup = _bloodGroup ?? new BloodGroupRepository(_context);

        public IDoctorRepository Doctor
            => _doctor = _doctor ?? new DoctorRepository(_context);

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
            => _context.Dispose();
    }
}
