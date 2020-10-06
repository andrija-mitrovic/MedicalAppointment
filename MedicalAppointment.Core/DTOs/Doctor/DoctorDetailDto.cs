using MedicalAppointment.Core.DTOs.Appointment;
using MedicalAppointment.Core.DTOs.Department;
using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Doctor
{
    public class DoctorDetailDto
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public DepartmentDetailDto Department { get; set; }
    }
}
