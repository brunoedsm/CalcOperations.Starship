using System;
using System.Collections.Generic;
using System.Linq;
using CalcOperations.Starship.Business.Entities;
using CalcOperations.Starship.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace CalcOperations.Starship.Business.Test
{
    public class StopCalculationServiceTest
    {
        private IConfiguration configuration;
        public StopCalculationServiceTest()
        {
            // Due the fact that we consume external resource, this will be configured like integration test
            configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", false)
                   .Build();
        }

        [Fact]
        public void Service_Should_Return_Expected_Value()
        {
            // Arrange
            var distanceInMegLights = 1000000;
            var externalStarshipService = Substitute.For<ExternalStarshipService>(Substitute.For<IConfiguration>(),Substitute.For<ILogger<ExternalStarshipService>>());
            var externalStarshipServiceResult = new List<StarshipResult>(){
                new StarshipResult(){
                     Name = "Millennium Falcon",
                 MGLT = "75",
                 Consumables = "2 months"
                }
            };
            externalStarshipService.GetAll().Returns(externalStarshipServiceResult);
            var expectedStarshipResult = new StopCalculationResult()
            {
                StarshipName = "Millennium Falcon",
                TotalStops = 9
            };
            var service = new StopCalculationService(Substitute.For<ILogger<StopCalculationService>>(),externalStarshipService);

            // Act 
            var result = service.GetStopCalculationFromStarships(distanceInMegLights);

            // Assert
            Assert.NotNull(result.First());
            Assert.Equal(expectedStarshipResult.StarshipName,result.First().StarshipName);
            Assert.Equal(expectedStarshipResult.TotalStops,result.First().TotalStops);
        }
    }
}