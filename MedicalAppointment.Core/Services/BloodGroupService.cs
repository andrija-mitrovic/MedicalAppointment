using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class BloodGroupService : IBloodGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BloodGroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetBloodGroupsNumber()
        {
            return await _unitOfWork.BloodGroups.GetTotalNumberOfBloodGroups();
        }
    }
}
