using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CalcOperations.Starship.Business.Services.Interfaces;
using CalcOperations.Starship.Business.Services;
using CalcOperations.Starship.Business.Entities;
using System.Collections.Generic;

namespace CalcOperations.Starship.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();

            var service = startup.Provider.GetRequiredService<IStopCalculationService>();

            SetTitle();
            string input = GetUserInput();

            while (input.ToUpper() != "Q")
            {
                double distanceInMegaLights = 0;
                if (double.TryParse(input, out distanceInMegaLights))
                {
                    Console.WriteLine($"Loading results for {distanceInMegaLights} MegaLights...\r\n");
                    var results = service.GetStopCalculationFromStarships(distanceInMegaLights);
                    WriteResults(results);
                    input = GetUserInput();
                }
                else
                {
                    input = GetUserInput(true);
                }
            }

        }

        private static void WriteResults(List<StopCalculationResult> results)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            results.ForEach(delegate (StopCalculationResult result)
            {
                Console.WriteLine($"{result.StarshipName} : {result.TotalStops}");
            });
            Console.ResetColor();
            Console.WriteLine("\r\n");
        }

        private static void SetTitle()
        {
            Console.Title = "StopCalculationStarship Client";
            Console.Clear();
            Console.WriteLine("Welcome to StopCalculationStarship Client!");
        }
        private static string GetUserInput(bool wrongValue = false, bool tryAgain = false)
        {
            if (wrongValue)
                Console.WriteLine("Please type a valid (numeric) input, or press 'Q' to Quit:");
            else
                Console.WriteLine("Type the distance value in MegaLights or press 'Q' to Quit:");

            string input = Console.ReadLine();
            return input;
        }
    }
}
