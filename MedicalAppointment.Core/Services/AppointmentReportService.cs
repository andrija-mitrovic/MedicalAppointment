using MedicalAppointment.Core.DTOs.Appointment;
using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class AppointmentReportService
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentReportService(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<AppointmentReportDto> Create()
        {
            return new AppointmentReportDto()
            {
                TotalNumber = await _appointmentService.GetAppointmentsNumber()
            };
        }
    }
}
