using MedicalAppointment.Core.DTOs.Patient;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetPatientsNumberAsync()
        {
            return await _unitOfWork.Patients.GetTotalNumberOfPatientsAsync();
        }

        public List<PatientsNumberByYears> GetPatientsNumberByYear()
        {
            return _unitOfWork.Patients.GetPatientsNumberByAgeAsync();
        }
    }
}
