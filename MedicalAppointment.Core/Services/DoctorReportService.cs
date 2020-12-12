using MedicalAppointment.Core.DTOs.Doctor;
using MedicalAppointment.Core.DTOs.Patient;
using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class DoctorReportService
    {
        private readonly IDoctorService _doctorService;

        public DoctorReportService(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<DoctorReportDto> Create()
        {
            return new DoctorReportDto()
            {
                TotalNumber = await _doctorService.GetDoctorsNumber()
            };
        }
    }
}
