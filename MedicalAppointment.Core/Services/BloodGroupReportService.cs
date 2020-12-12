using MedicalAppointment.Core.DTOs.BloodGroup;
using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class BloodGroupReportService
    {
        private readonly IBloodGroupService _bloodGroupService;

        public BloodGroupReportService(IBloodGroupService bloodGroupService)
        {
            _bloodGroupService = bloodGroupService;
        }

        public async Task<BloodGroupReportDto> Create()
        {
            return new BloodGroupReportDto()
            {
                TotalNumber = await _bloodGroupService.GetBloodGroupsNumber()
            };
        }
    }
}
