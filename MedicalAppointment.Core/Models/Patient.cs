using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int BloodGroupId { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
