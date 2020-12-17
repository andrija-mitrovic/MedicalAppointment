using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.Interfaces
{
    public interface IUserRepository:IGenericRepository<User>
    {
        User FindUser(int id);
    }
}
