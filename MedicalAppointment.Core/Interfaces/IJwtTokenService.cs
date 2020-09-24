using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken(User user);
    }
}
