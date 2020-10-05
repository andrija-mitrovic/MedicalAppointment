using MedicalAppointment.Core.DTOs.BloodGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Patient
{
    public class PatientDetailDto
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public BloodGroupDetailDto BloodGroup { get; set; }
    }
}
