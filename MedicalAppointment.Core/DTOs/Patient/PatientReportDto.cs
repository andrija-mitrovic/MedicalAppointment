using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.DTOs.Patient
{
    public class PatientReportDto
    {
        public int TotalNumber { get; set; }
        public List<Point> ChartData { get; set; }
    }

    public class Point
    {
        public int Number { get; set; }
        public int Age { get; set; }
    }
}
