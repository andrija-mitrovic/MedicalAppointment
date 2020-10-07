using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicalAppointment.Core.DTOs.Appointment;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentsController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/appointments
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _unitOfWork.Appointments.GetAppointmentsWithPatientDoctorDepartment();
            var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDetailDto>>(appointments);

            return Ok(appointmentsDto);
        }

        // GET: api/appointments/5
        [HttpGet("{id}", Name = "GetAppointment")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetAppointmentWithPatientDoctorDepartmentById(id);
            var appointmentDto = _mapper.Map<AppointmentDetailDto>(appointment);

            return Ok(appointmentDto);
        }

        // POST: api/appointments/5
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentCreateDto appointmentCreateDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentCreateDto);

            await _unitOfWork.Appointments.AddAsync(appointment);

            if (await _unitOfWork.SaveAsync())
            {
                var appointmentToReturn = _mapper.Map<AppointmentReturnDto>(appointment);
                return CreatedAtRoute("GetAppointment", new { id = appointment.AppointmentId}, appointmentToReturn);
            }

            throw new Exception("Creating appointment failed on save");
        }

        // PUT: api/appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, AppointmentUpdateDto appointmentUpdateDto)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            _mapper.Map(appointmentUpdateDto, appointment);

            _unitOfWork.Appointments.Update(appointment);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Updating appointment {id} failed to save");
        }

        // DELETE: api/appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetAppointmentWithPatientDoctorDepartmentById(id);

            if (appointment == null)
                return NotFound();

            _unitOfWork.Appointments.Remove(appointment);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Deleting appointment {id} failed on save");
        }
    }
}
