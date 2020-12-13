using MedicalAppointment.Core.DTOs.Patient;
using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class PatientReportService
    {
        private readonly IPatientService _patientService;

        public PatientReportService(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<PatientReportDto> Create()
        {
            var patients = _patientService.GetPatientsNumberByYear();

            List<Point> chartPoints = new List<Point>();

            foreach(var patient in patients)
            {
                chartPoints.Add(new Point()
                {
                    Number = patient.Number,
                    Age = DateTime.Now.Year - patient.Year
                });
            }
            return new PatientReportDto()
            {
                TotalNumber = await _patientService.GetPatientsNumber(),
                ChartData = chartPoints
            };
        }
    }
}
