using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class PatientRepository:GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }
    }
}
