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

        public async Task<int> GetTotalNumberOfMalePatient()
        {
            return await _context.Patients.CountAsync(x => x.Gender.ToUpper() == "MALE");  
        }

        public async Task<int> GetTotalNumberOfFemalePatient()
        {
            return await _context.Patients.CountAsync(x => x.Gender.ToUpper() == "FEMALE");
        }

        public async Task<int> GetTotalNumberOfPatients()
        {
            return await _context.Patients.CountAsync();
        }
    }
}
