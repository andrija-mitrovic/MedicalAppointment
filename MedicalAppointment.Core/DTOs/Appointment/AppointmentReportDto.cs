using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Appointment
{
    public class AppointmentReportDto
    {
        public int TotalNumber { get; set; }
        public decimal MontlyGrowthPercent { get; set; }
    }
}
