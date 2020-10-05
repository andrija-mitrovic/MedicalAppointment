using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicalAppointment.Core.DTOs.Patient;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientsController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/patients
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _unitOfWork.Patients.GetAllAsync();
            var patientsDto = _mapper.Map<IEnumerable<PatientDetailDto>>(patients);

            return Ok(patientsDto);
        }

        // GET: api/patients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);

            if (patient == null)
                return NotFound();

            var patientDto = _mapper.Map<PatientDetailDto>(patient);

            return Ok(patientDto);
        }

        // POST: api/patients
        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientCreateDto patientCreateDto)
        {
            var patient = _mapper.Map<Patient>(patientCreateDto);

            await _unitOfWork.Patients.AddAsync(patient);

            if (await _unitOfWork.SaveAsync())
                return StatusCode(201);

            throw new Exception("Creating patient failed on save");
        }

        // PUT: api/patients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientUpdateDto patientUpdateDto)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);

            if (patient == null)
                return NotFound();

            _mapper.Map(patientUpdateDto, patient);

            _unitOfWork.Patients.Update(patient);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Updating patient {id} failed to save");
        }

        // DELETE: api/doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);

            if (patient == null)
                return NotFound();

            _unitOfWork.Patients.Remove(patient);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Deleting patient {id} failed on save");
        }
    }
}
