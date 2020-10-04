using CalcOperations.Starship.Business.Builders;
using CalcOperations.Starship.Business.Entities;
using Xunit;

namespace CalcOperations.Starship.Business.Test
{
    public class StopCalculationResultBuilderTest
    {

        [Fact]
        public void Builder_Should_Calculate_And_Create_Valid_Response()
        {
            // Arrange know result
            var megaLights = 1000000;
            var starship = new StarshipResult(){
                 Name = "Millennium Falcon",
                 MGLT = "75",
                 Consumables = "2 months"
             };
            var stopsExpected = 9;

            // Act 
            var result = StopCalculationResultBuilder.Build(starship,megaLights);

            // Assert
            Assert.Equal(stopsExpected,result.TotalStops);
            
        }

        
    }
}