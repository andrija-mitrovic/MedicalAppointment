using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class BloodGroupRepository:GenericRepository<BloodGroup>, IBloodGroupRepository
    {
        public BloodGroupRepository(ApplicationDbContext context) : base(context) { }
    }
}
