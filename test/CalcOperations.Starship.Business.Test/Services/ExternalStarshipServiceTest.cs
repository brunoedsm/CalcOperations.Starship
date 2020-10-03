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
            configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", false)
                   .Build();
        }

        [Fact]
        public void Service_Should_Return_List_Of_Starships()
        {
            var service = new ExternalStarshipService(configuration, Substitute.For<ILogger<ExternalStarshipService>>());

            var result = service.GetAll();

            Assert.NotNull(result);
        }
    }
}