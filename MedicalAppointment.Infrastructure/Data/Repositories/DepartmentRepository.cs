using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class DepartmentRepository:GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context) { }
    }
}
