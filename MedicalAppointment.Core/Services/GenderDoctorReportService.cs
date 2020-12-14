using MedicalAppointment.Core.DTOs.Gender;
using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class GenderDoctorReportService
    {
        private readonly IGenderService _genderService;

        public GenderDoctorReportService(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public async Task<GenderReportDto> Create()
        {
            return new GenderReportDto()
            {
                MaleNumber = await _genderService.GetMaleDoctorsNumber(),
                MalePercent = await _genderService.GetPercentOfMaleDoctorGender(),
                FemaleNumber = await _genderService.GetFemaleDoctorsNumber(),
                FemalePercent = await _genderService.GetPercentOfFemaleDoctorGender()
            };
        }
    }
}
