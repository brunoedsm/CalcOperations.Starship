using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CalcOperations.Starship.Business.Services.Interfaces;
using CalcOperations.Starship.Business.Services;
using CalcOperations.Starship.Business.Entities;

namespace CalcOperations.Starship.Client
{
    public class Startup
    {
        public IServiceProvider Provider { get; set; }
        public IConfiguration Configuration { get; set; }
        public Startup()
        {
            // Add configuration file
            Configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", false)
                            .Build();
            // DI
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddLogging();
            services.AddSingleton<IExternalStarshipService, ExternalStarshipService>();
            services.AddSingleton<IStopCalculationService, StopCalculationService>();
            Provider = services.BuildServiceProvider();
        }
    }
}
