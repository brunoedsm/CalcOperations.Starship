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
        private readonly IConfiguration configuration;
        private readonly IServiceProvider provider;
        public IServiceProvider Provider => provider;
        public IConfiguration Configuration => configuration;
        public Startup()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddLogging();
            services.AddSingleton<IExternalStarshipService, ExternalStarshipService>();
            services.AddSingleton<IStopCalculationService, StopCalculationService>();
            configuration.AddJsonFile("appsettings.json", false)
                         .Build();

            provider = services.BuildServiceProvider();
        }
    }
}
