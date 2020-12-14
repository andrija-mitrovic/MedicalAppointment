using MedicalAppointment.Core.DTOs.Dashboard;
using MedicalAppointment.Core.DTOs.Doctor;
using MedicalAppointment.Core.DTOs.Gender;
using MedicalAppointment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointment.Core.Services
{
    public class DashboardReportService
    {
        private readonly GenderPatientReportService _genderPatientReportService;
        private readonly GenderDoctorReportService _genderDoctorReportService;
        private readonly PatientReportService _patientReportService;
        private readonly DoctorReportService _doctorReportService;
        private readonly BloodGroupReportService _bloodGroupReportService;
        private readonly AppointmentReportService _appointmentReportService;
        private readonly IGenderService _genderService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IBloodGroupService _bloodGroupService;
        private readonly IAppointmentService _appointmentService;

        public DashboardReportService(
            IGenderService genderService,
            IPatientService patientService,
            IDoctorService doctorService,
            IBloodGroupService bloodGroupService,
            IAppointmentService appointmentService
            )
        {
            _genderService = genderService;
            _patientService = patientService;
            _doctorService = doctorService;
            _bloodGroupService = bloodGroupService;
            _appointmentService = appointmentService;
            _genderPatientReportService = new GenderPatientReportService(_genderService);
            _genderDoctorReportService = new GenderDoctorReportService(_genderService);
            _patientReportService = new PatientReportService(_patientService);
            _doctorReportService = new DoctorReportService(_doctorService);
            _bloodGroupReportService = new BloodGroupReportService(_bloodGroupService);
            _appointmentReportService = new AppointmentReportService(_appointmentService);
        }

        public async Task<DashboardReportDto> CreateReport()
        {

            var dashboardData = new DashboardReportDto()
            {
                AppointmentReport = await _appointmentReportService.Create(),
                BloodGroupReport = await _bloodGroupReportService.Create(),
                DoctorReport = await _doctorReportService.Create(),
                PatientReport = await _patientReportService.Create(),
                GenderPatientReport = await _genderPatientReportService.Create(),
                GenderDoctorReport = await _genderDoctorReportService.Create()
            };

            return dashboardData;
        }

    }
}
