using System;
using System.Collections.Generic;
using CalcOperations.Starship.Business.Entities;
using CalcOperations.Starship.Business.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CalcOperations.Starship.Business.Services
{

    public class ExternalStarshipService : IExternalStarshipService
    {
        private readonly string externalServiceEndpoint;
        private readonly ILogger _logger;
        private int pagination;
        public ExternalStarshipService(IConfiguration config,ILogger<ExternalStarshipService> logger)
        {
            _logger = logger;
            externalServiceEndpoint = config.GetValue<string>("application:swapi_endpoint_starships") ?? throw new NullReferenceException("External SWAPI address not found");
            pagination = 1;
        }
        public async Task<List<StarshipResult>> GetAll()
        {
            var result = new List<StarshipResult>();

            var starshipResponse = await externalServiceEndpoint.SetQueryParam("page",pagination).GetJsonAsync<StarshipResponse>();
            result.AddRange(starshipResponse.Results);

            while(starshipResponse.Next != null)
            {
                pagination++;
                starshipResponse = await externalServiceEndpoint.SetQueryParam("page",pagination).GetJsonAsync<StarshipResponse>();
                result.AddRange(starshipResponse.Results);   
            }
            return result;
        }
    }

}