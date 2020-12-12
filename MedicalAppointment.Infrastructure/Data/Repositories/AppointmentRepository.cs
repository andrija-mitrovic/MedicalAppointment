using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class AppointmentRepository:GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Appointment>> GetAppointmentsWithPatientDoctorDepartment()
        {
            return await _context.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .Include(x => x.Department).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentWithPatientDoctorDepartmentById(int id)
        {
            return await _context.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.AppointmentId == id);
        }

        public async Task<int> GetTotalNumberOfAppointments()
        {
            return await _context.Appointments.CountAsync();
        }
    }
}
