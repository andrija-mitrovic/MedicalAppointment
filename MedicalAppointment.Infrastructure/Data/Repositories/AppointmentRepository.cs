using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class AppointmentRepository:GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context) { }
    }
}
