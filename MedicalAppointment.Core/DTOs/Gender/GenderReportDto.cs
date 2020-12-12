using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Gender
{
    public class GenderReportDto
    {
        public int MaleNumber { get; set; }
        public decimal MalePercent { get; set; }
        public int FemaleNumber { get; set; }
        public decimal FemalePercent { get; set; }
    }
}
