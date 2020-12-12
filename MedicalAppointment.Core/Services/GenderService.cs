using MedicalAppointment.Core.DTOs.Gender;
using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class GenderService : IGenderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetMalePatientNumber()
        {
            return await _unitOfWork.Patients.GetTotalNumberOfMalePatient();
        }

        public async Task<int> GetFemalePatientNumber()
        {
            return await _unitOfWork.Patients.GetTotalNumberOfFemalePatient();
        }

        public async Task<decimal> GetPercentOfMaleGender()
        {
            int maleNumber = await GetMalePatientNumber();
            int femaleNumber = await GetFemalePatientNumber();

            return ((decimal)maleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }

        public async Task<decimal> GetPercentOfFemaleGender()
        {
            int maleNumber = await GetMalePatientNumber();
            int femaleNumber = await GetFemalePatientNumber();

            return ((decimal)femaleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }
    }
}
