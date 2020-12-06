using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class PatientRepository:GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Patient>> GetPatientWithBloodGroup()
        {
            return await _context.Patients.Include(x => x.BloodGroup).ToListAsync();
        }
        public async Task<Patient> GetPatientWithBloodGroupById(int id)
        {
            return await _context.Patients.Include(x => x.BloodGroup).FirstOrDefaultAsync(x => x.PatientId == id);
        }
    }
}
