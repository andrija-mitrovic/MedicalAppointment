using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Appointment
{
    public class AppointmentReturnDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Symptoms { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }
    }
}
