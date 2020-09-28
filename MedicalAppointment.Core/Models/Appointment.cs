using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Symptoms { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Department Department { get; set; }
    }
}
