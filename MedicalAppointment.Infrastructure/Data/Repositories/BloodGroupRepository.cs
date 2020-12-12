using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class BloodGroupRepository:GenericRepository<BloodGroup>, IBloodGroupRepository
    {
        public BloodGroupRepository(ApplicationDbContext context) : base(context) { }

        public async Task<int> GetTotalNumberOfBloodGroups()
        {
            return await _context.BloodGroups.CountAsync();
        }
    }
}
