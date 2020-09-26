using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
