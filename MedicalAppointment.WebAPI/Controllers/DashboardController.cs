using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardReportService _dashboardReportService;

        public DashboardController(
            DashboardReportService dashboardReportService
            )
        {
            _dashboardReportService = dashboardReportService;
        }

        // GET: api/dashboard
        [HttpGet]
        public async Task<IActionResult> GetDashboardData()
        {
            var dashboardReport = await _dashboardReportService.CreateReport();

            return Ok(dashboardReport);
        }
    }
}