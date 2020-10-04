using CalcOperations.Starship.Business.Extensions;
using Xunit;

namespace CalcOperations.Starship.Business.Test
{
    public class StringToHourExtensionTest
    {

        [Fact]
        public void Extension_Should_Return_When_Description_Is_Singular_Or_Plural()
        {
            // Arrange know result
            var singularTime = "1 year";
            var pluralTime = "2 years";
            var invalidTime = "unknown";
            var invalidTime2 = "1 second";
            var singularHoursExpected = 8760;
            var pluralHoursExpected = 17520;
            var invalidHourExpected = 0;
            var invalidHourExpected2 = 0;    
            
            // Act 
            var resultOne = singularTime.ToHours();
            var resultTwo = pluralTime.ToHours();
            var resultThree = invalidTime.ToHours();
            var resultFour = invalidTime2.ToHours();

            // Assert
            Assert.Equal(singularHoursExpected,resultOne);
            Assert.Equal(pluralHoursExpected,resultTwo);
            Assert.Equal(invalidHourExpected,resultThree);
            Assert.Equal(invalidHourExpected2,resultFour);
        }

        
    }
}