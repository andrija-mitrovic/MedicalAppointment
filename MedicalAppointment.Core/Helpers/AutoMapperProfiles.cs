using AutoMapper;
using MedicalAppointment.Core.DTOs.Appointment;
using MedicalAppointment.Core.DTOs.BloodGroup;
using MedicalAppointment.Core.DTOs.Department;
using MedicalAppointment.Core.DTOs.Doctor;
using MedicalAppointment.Core.DTOs.Patient;
using MedicalAppointment.Core.DTOs.User;
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

            CreateMap<PatientCreateDto, Patient>();
            CreateMap<PatientUpdateDto, Patient>();
            CreateMap<Patient, PatientDetailDto>();

            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<AppointmentUpdateDto, Appointment>();
            CreateMap<Appointment, AppointmentDetailDto>();
            CreateMap<Appointment, AppointmentReturnDto>();
        }
    }
}
