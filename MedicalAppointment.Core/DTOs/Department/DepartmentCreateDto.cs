using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Department
{
    public class DepartmentCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
