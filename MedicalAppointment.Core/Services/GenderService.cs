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

        public async Task<decimal> GetPercentOfMalePatientGender()
        {
            int maleNumber = await GetMalePatientNumber();
            int femaleNumber = await GetFemalePatientNumber();

            return ((decimal)maleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }

        public async Task<decimal> GetPercentOfFemalePatientGender()
        {
            int maleNumber = await GetMalePatientNumber();
            int femaleNumber = await GetFemalePatientNumber();

            return ((decimal)femaleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }

        public async Task<int> GetMaleDoctorsNumber()
        {
            return await _unitOfWork.Doctors.GetTotalNumberOfMaleDoctor();
        }

        public async Task<int> GetFemaleDoctorsNumber()
        {
            return await _unitOfWork.Doctors.GetTotalNumberOfFemaleDoctor();
        }

        public async Task<decimal> GetPercentOfMaleDoctorGender()
        {
            int maleNumber = await GetMaleDoctorsNumber();
            int femaleNumber = await GetFemaleDoctorsNumber();

            return ((decimal)maleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }

        public async Task<decimal> GetPercentOfFemaleDoctorGender()
        {
            int maleNumber = await GetMaleDoctorsNumber();
            int femaleNumber = await GetFemaleDoctorsNumber();

            return ((decimal)femaleNumber / (decimal)(maleNumber + femaleNumber)) * 100;
        }
    }
}
