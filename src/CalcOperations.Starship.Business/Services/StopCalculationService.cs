using System;
using System.Collections.Generic;
using System.Configuration;
using CalcOperations.Starship.Business.Builders;
using CalcOperations.Starship.Business.Entities;
using CalcOperations.Starship.Business.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace CalcOperations.Starship.Business.Services
{
    public class StopCalculationService : IStopCalculationService
    {
        private readonly ILogger _logger;
        private readonly IExternalStarshipService _externalStarshipService;
        public StopCalculationService(ILogger<StopCalculationService> logger,IExternalStarshipService externalStarshipService)
        {
            _logger = logger;
            _externalStarshipService = externalStarshipService;
        }
        public List<StopCalculationResult> GetStopCalculationFromStarships(double distanceInMegaLights)
        {
            var result = new List<StopCalculationResult>();

            var starships = _externalStarshipService.GetAll().Result;

            starships.ForEach(delegate(StarshipResult starship){
                result.Add(StopCalculationResultBuilder.Build(starship,distanceInMegaLights));
            });

            return result;
        }
    }

}