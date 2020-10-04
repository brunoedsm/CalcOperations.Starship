using System;
using CalcOperations.Starship.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace CalcOperations.Starship.Business.Test
{
    public class ExternalStarshipServiceTest
    {
        private IConfiguration configuration;
        // Setup
        public ExternalStarshipServiceTest()
        {
            // Due the fact that we consume external resource, this will be configured like integration test
            configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", false)
                   .Build();
        }

        [Fact]
        public void Service_Should_Throw_When_Missing_Endpoint()
        {
            //Act && Assert
            Assert.Throws<NullReferenceException>(() => new ExternalStarshipService(null, Substitute.For<ILogger<ExternalStarshipService>>()));
        }

        [Fact]
        public void Service_Should_Not_Throw_When_Endpoint_Configured()
        {
            // Arrange
            var service = new ExternalStarshipService(configuration, Substitute.For<ILogger<ExternalStarshipService>>());

            // Act && Assert
            var response = service.GetAll();

            Assert.NotNull(response.Result);
        }
    }
}