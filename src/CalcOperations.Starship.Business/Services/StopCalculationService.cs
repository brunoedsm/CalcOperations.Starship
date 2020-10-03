using System;
using System.Collections.Generic;
using System.Configuration;
using CalcOperations.Starship.Business.Entities;
using CalcOperations.Starship.Business.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace CalcOperations.Starship.Business.Services
{

    public class StopCalculationService : IStopCalculationService
    {
        private readonly ILogger _logger;
        public StopCalculationService(ILogger<StopCalculationService> logger)
        {
            _logger = logger;
        }
        public List<StarshipResult> GetAll()
        {
            return null;
        }
    }

}