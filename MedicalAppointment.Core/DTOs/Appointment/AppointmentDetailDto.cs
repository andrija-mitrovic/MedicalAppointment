using MedicalAppointment.Core.DTOs.Department;
using MedicalAppointment.Core.DTOs.Doctor;
using MedicalAppointment.Core.DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Appointment
{
    public class AppointmentDetailDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Symptoms { get; set; }
        public PatientDetailDto Patient { get; set; }
        public DoctorDetailDto Doctor { get; set; }
        public DepartmentDetailDto Department { get; set; }
    }
}
