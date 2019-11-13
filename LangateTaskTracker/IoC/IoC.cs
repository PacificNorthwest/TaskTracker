using LangateTaskTracker.Business.Services;
using LangateTaskTracker.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangateTaskTracker.WebServer.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddTrackerServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskTrackerService, TaskTrackerService>();
            return services;
        }
    }
}
