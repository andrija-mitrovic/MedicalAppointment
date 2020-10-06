using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Appointment
{
    public class AppointmentCreateDto
    {
        public DateTime AppointmentDate { get; set; }
        public string Symptoms { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }
    }
}
