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

        public async Task<int> GetMalePatientNumberAsync()
        {
            return await _unitOfWork.Patients.GetTotalNumberOfMalePatientAsync();
        }

        public async Task<int> GetFemalePatientNumberAsync()
        {
            return await _unitOfWork.Patients.GetTotalNumberOfFemalePatientAsync();
        }

        public async Task<decimal> GetPercentOfMalePatientGenderAsync()
        {
            int maleNumber = await GetMalePatientNumberAsync();
            int femaleNumber = await GetFemalePatientNumberAsync();

            return ((decimal)maleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }

        public async Task<decimal> GetPercentOfFemalePatientGenderAsync()
        {
            int maleNumber = await GetMalePatientNumberAsync();
            int femaleNumber = await GetFemalePatientNumberAsync();

            return ((decimal)femaleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }

        public async Task<int> GetMaleDoctorsNumberAsync()
        {
            return await _unitOfWork.Doctors.GetTotalNumberOfMaleDoctorAsync();
        }

        public async Task<int> GetFemaleDoctorsNumberAsync()
        {
            return await _unitOfWork.Doctors.GetTotalNumberOfFemaleDoctorAsync();
        }

        public async Task<decimal> GetPercentOfMaleDoctorGenderAsync()
        {
            int maleNumber = await GetMaleDoctorsNumberAsync();
            int femaleNumber = await GetFemaleDoctorsNumberAsync();

            return ((decimal)maleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }

        public async Task<decimal> GetPercentOfFemaleDoctorGenderAsync()
        {
            int maleNumber = await GetMaleDoctorsNumberAsync();
            int femaleNumber = await GetFemaleDoctorsNumberAsync();

            return ((decimal)femaleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }
    }
}
