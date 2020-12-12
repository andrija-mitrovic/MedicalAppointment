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
            return new PatientReportDto()
            {
                TotalNumber = await _patientService.GetPatientsNumber()
            };
        }
    }
}
