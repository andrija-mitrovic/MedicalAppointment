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

        public async Task<IEnumerable<Doctor>> GetDoctorsWithDepartment()
        {
            return await _context.Doctors.Include(x => x.Department).ToListAsync();
        }

        public async Task<Doctor> GetDoctorWithDepartment(int id)
        {
            return await _context.Doctors.Include(x => x.Department).FirstOrDefaultAsync(x => x.DoctorId == id);
        }
    }
}
