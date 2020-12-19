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

        public async Task<GenderReportDto> CreateAsync()
        {
            return new GenderReportDto()
            {
                MaleNumber =  await _genderService.GetMalePatientNumberAsync(),
                MalePercent = await _genderService.GetPercentOfMalePatientGenderAsync(),
                FemaleNumber = await _genderService.GetFemalePatientNumberAsync(),
                FemalePercent = await _genderService.GetPercentOfFemalePatientGenderAsync()
            };
        }
    }
}
