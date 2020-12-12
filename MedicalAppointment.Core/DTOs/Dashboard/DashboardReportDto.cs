using MedicalAppointment.Core.DTOs.Appointment;
using MedicalAppointment.Core.DTOs.BloodGroup;
using MedicalAppointment.Core.DTOs.Doctor;
using MedicalAppointment.Core.DTOs.Gender;
using MedicalAppointment.Core.DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Dashboard
{
    public class DashboardReportDto
    {
        public BloodGroupReportDto BloodGroupReport { get; set; }
        public AppointmentReportDto AppointmentReport { get; set; }
        public DoctorReportDto DoctorReport { get; set; }
        public PatientReportDto PatientReport { get; set; }
        public GenderReportDto GenderReport { get; set; }
    }
}
