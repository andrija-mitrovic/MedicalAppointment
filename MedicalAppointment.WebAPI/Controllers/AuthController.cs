using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MedicalAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(
            IConfiguration config,
            IMapper mapper,
            IJwtTokenService jwtTokenService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _config = config;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
    }
}
