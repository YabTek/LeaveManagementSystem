using HR.LeaveManagement.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
// using HR.LeaveManagement.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HR.LeaveManagement.Application;

 public static class ApplicationServiceRegistration{
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services){
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // services.AddSingleton<IEmailSender, EmailSender>();

            return services;
        }
    }
