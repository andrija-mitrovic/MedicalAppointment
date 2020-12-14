using MedicalAppointment.Core.DTOs.Gender;
using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class GenderPatientReportService
    {
        private readonly IGenderService _genderService;

        public GenderPatientReportService(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public async Task<GenderReportDto> Create()
        {
            return new GenderReportDto()
            {
                MaleNumber =  await _genderService.GetMalePatientNumber(),
                MalePercent = await _genderService.GetPercentOfMalePatientGender(),
                FemaleNumber = await _genderService.GetFemalePatientNumber(),
                FemalePercent = await _genderService.GetPercentOfFemalePatientGender()
            };
        }
    }
}
