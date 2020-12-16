using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Infrastructure.Data.Repositories
{
    public class UserRepository: GenericRepository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}
