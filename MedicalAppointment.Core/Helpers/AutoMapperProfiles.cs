using AutoMapper;
using MedicalAppointment.Core.DTOs;
using MedicalAppointment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalAppointment.Core.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserDetailDto>();
            CreateMap<BloodGroupUpdateDto, BloodGroup>();
            CreateMap<BloodGroupCreateDto, BloodGroup>();
            CreateMap<BloodGroup, BloodGroupDetailDto>();
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Department, DepartmentDetailDto>();
            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<DoctorUpdateDto, Doctor>();
            CreateMap<Doctor, DoctorDetailDto>();
        }
    }
}
