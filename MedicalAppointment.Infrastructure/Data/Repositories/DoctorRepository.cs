using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class DoctorRepository:GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Doctor>> GetDoctorsWithDepartmentAsync()
        {
            return await _context.Doctors.Include(x => x.Department).ToListAsync();
        }

        public async Task<Doctor> GetDoctorWithDepartmentByIdAsync(int id)
        {
            return await _context.Doctors.Include(x => x.Department).FirstOrDefaultAsync(x => x.DoctorId == id);
        }

        public async Task<int> GetTotalNumberOfDoctorsAsync()
        {
            return await _context.Doctors.CountAsync();
        }

        public async Task<int> GetTotalNumberOfFemaleDoctorAsync()
        {
            return await _context.Doctors.CountAsync(x => x.Gender.ToUpper() == "MALE");
        }

        public async Task<int> GetTotalNumberOfMaleDoctorAsync()
        {
            return await _context.Doctors.CountAsync(x => x.Gender.ToUpper() == "MALE");
        }
    }
}
