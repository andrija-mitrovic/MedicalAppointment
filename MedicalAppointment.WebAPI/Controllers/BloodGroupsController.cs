using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MedicalAppointment.Core.DTOs.BloodGroup;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodGroupsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BloodGroupsController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/BloodGroups
        [HttpGet]
        public async Task<IActionResult> GetBloodGroups()
        {
            var bloodGroups = await _unitOfWork.BloodGroups.GetAllAsync();
            var bloodGroupsDto = _mapper.Map<IEnumerable<BloodGroupDetailDto>>(bloodGroups);
        
            return Ok(bloodGroupsDto);
        }

        // GET: api/BloodGroups/5
        [HttpGet("{id}", Name = "GetBloodGroup")]
        public async Task<IActionResult> GetBloodGroup(int id)
        {
            var bloodGroup = await _unitOfWork.BloodGroups.GetByIdAsync(id);

            if (bloodGroup == null)
                return NotFound();

            var bloodGroupDto = _mapper.Map<BloodGroupDetailDto>(bloodGroup);

            return Ok(bloodGroupDto);
        }

        // POST: api/BloodGroups
        [HttpPost]
        public async Task<IActionResult> CreateBloodGroup(BloodGroupCreateDto bloodGroupCreateDto)
        {
            var bloodGroup = _mapper.Map<BloodGroup>(bloodGroupCreateDto);

            await _unitOfWork.BloodGroups.AddAsync(bloodGroup);

            if (await _unitOfWork.SaveAsync())
            {
                var bloodGroupToReturn = _mapper.Map<BloodGroupDetailDto>(bloodGroup);
                return CreatedAtRoute("GetBloodGroup", new { id = bloodGroup.BloodGroupId }, bloodGroupToReturn);
            }

            throw new Exception("Creating blood group failed on save");
        }

        // PUT: api/BloodGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBloodGroup(int id, BloodGroupUpdateDto bloodGroupUpdateDto)
        {
            var bloodGroup = await _unitOfWork.BloodGroups.GetByIdAsync(id);

            if (bloodGroup == null)
                return NotFound();

            _mapper.Map(bloodGroupUpdateDto, bloodGroup);

            _unitOfWork.BloodGroups.Update(bloodGroup);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Updating blood group {id} failed to save");
        }

        // DELETE: api/BloodGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloodGroup(int id)
        {
            var bloodGroup = await _unitOfWork.BloodGroups.GetByIdAsync(id);

            if (bloodGroup == null)
                return NotFound();

            _unitOfWork.BloodGroups.Remove(bloodGroup);

            if (await _unitOfWork.SaveAsync())
                return NoContent();

            throw new Exception($"Deleting blood group {id} failed on save");
        }
    }
}
