using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicalAppointment.Core.DTOs.Doctor;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorsController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _unitOfWork.Doctors.GetDoctorsWithDepartment();
            var doctorsDto = _mapper.Map<IEnumerable<DoctorDetailDto>>(doctors);

            return Ok(doctorsDto);
        }

        // GET: api/Doctors/5
        [HttpGet("{id}", Name = "GetDoctor")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetDoctorWithDepartmentById(id);

            if (doctor == null)
                return NotFound();

            var doctorDto = _mapper.Map<DoctorDetailDto>(doctor);

            return Ok(doctorDto);
        }

        // POST: api/Doctors
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorCreateDto doctorCreateDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorCreateDto);

            await _unitOfWork.Doctors.AddAsync(doctor);

            if (await _unitOfWork.SaveAsync())
            {
                var doctorToReturn = _mapper.Map<DoctorDetailDto>(doctor);
                return CreatedAtRoute("GetDoctor", new { id = doctor.DoctorId }, doctorToReturn);
            }

            throw new Exception("Creating department failed on save");
        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorUpdateDto doctorUpdateDto)
        {
            var doctor= await _unitOfWork.Doctors.GetByIdAsync(id);

            if (doctor == null)
                return NotFound();

            _mapper.Map(doctorUpdateDto, doctor);

            _unitOfWork.Doctors.Update(doctor);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Updating doctor {id} failed to save");
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetDoctorWithDepartmentById(id);

            if (doctor == null)
                return NotFound();

            _unitOfWork.Doctors.Remove(doctor);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Deleting doctor {id} failed on save");
        }
    }
}
