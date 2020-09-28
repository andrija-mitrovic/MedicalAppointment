using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.Models
{
    public class BloodGroup
    {
        public int BloodGroupId { get; set; }
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
