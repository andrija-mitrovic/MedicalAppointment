using MedicalAppointment.Core.DTOs.Patient;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class PatientRepository:GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Patient>> GetPatientWithBloodGroupAsync()
        {
            return await _context.Patients.Include(x => x.BloodGroup).ToListAsync();
        }
        public async Task<Patient> GetPatientWithBloodGroupByIdAsync(int id)
        {
            return await _context.Patients.Include(x => x.BloodGroup).FirstOrDefaultAsync(x => x.PatientId == id);
        }

        public async Task<int> GetTotalNumberOfMalePatientAsync()
        {
            return await _context.Patients.CountAsync(x => x.Gender.ToUpper() == "MALE");  
        }

        public async Task<int> GetTotalNumberOfFemalePatientAsync()
        {
            return await _context.Patients.CountAsync(x => x.Gender.ToUpper() == "FEMALE");
        }

        public async Task<int> GetTotalNumberOfPatientsAsync()
        {
            return await _context.Patients.CountAsync();
        }

        public List<PatientsNumberByYears> GetPatientsNumberByAgeAsync()
        {
            return _context.PatientsNumberByYears
                .FromSqlRaw(@"SELECT COUNT(*) AS Number,
                              YEAR(CONVERT(DATE, DateOfBirth)) AS Year FROM Patients
                              GROUP BY YEAR(CONVERT(DATE, DateOfBirth))").ToList();
        }
    }
}
