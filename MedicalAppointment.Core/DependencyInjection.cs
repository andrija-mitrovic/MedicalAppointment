﻿using System.Reflection;
using AutoMapper;
using MedicalAppointment.Core.Interfaces;
using MedicalAppointment.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalAppointment.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.ConfigureInjection();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        private static void ConfigureInjection(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenService, JwtTokenService>();
        }
    }
}
