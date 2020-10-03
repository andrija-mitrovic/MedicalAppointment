using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicalAppointment.Core.DTOs;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentsController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();
            var departmentsDto = _mapper.Map<IEnumerable<DepartmentDetailDto>>(departments);

            return Ok(departmentsDto);
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            var departmentDto = _mapper.Map<DepartmentDetailDto>(department);

            return Ok(departmentDto);
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentCreateDto departmentCreateDto)
        {
            var department = _mapper.Map<Department>(departmentCreateDto);

            await _unitOfWork.Departments.AddAsync(department);

            if (await _unitOfWork.SaveAsync())
                return StatusCode(201);

            throw new Exception("Creating department failed on save");
        }

        // PUT: api/Departments
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentUpdateDto departmentUpdateDto)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            _mapper.Map(departmentUpdateDto, department);

            _unitOfWork.Departments.Update(department);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Updating department {id} failed to save");
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            _unitOfWork.Departments.Remove(department);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Deleting department {id} failed on save");
        }
    }
}
