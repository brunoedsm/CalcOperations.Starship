using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CalcOperations.Starship.Business.Services.Interfaces;
using CalcOperations.Starship.Business.Services;
using CalcOperations.Starship.Business.Entities;

namespace CalcOperations.Starship.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();

            var service = startup.Provider.GetRequiredService<IStopCalculationService>();

            Console.WriteLine("Welcome to StopCalculatorStarship Client!");
            Console.WriteLine("Type the distance value in MegaLights or press 'Q' to Quit:");

            string input = Console.ReadLine();

            while (input.ToUpper() != "Q")
            {
                double distanceInMegaLights = 0;
                if (double.TryParse(input, out distanceInMegaLights))
                {
                    var results = service.GetStopCalculationFromStarships(distanceInMegaLights);
                    results.ForEach(delegate(StopCalculationResult result){
                        Console.WriteLine($"{result.StarshipName} : {result.TotalStops}");
                    });

                    Console.WriteLine("Insert a new value to calculate, or press 'Q' to Quit:");
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please insert a valid (numeric) input, or press 'Q' to Quit:");
                    input = Console.ReadLine();
                }
            }

        }
    }
}
