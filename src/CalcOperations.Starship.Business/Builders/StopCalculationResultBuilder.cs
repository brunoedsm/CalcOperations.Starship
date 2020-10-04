using System;
using CalcOperations.Starship.Business.Entities;
using CalcOperations.Starship.Business.Extensions;

namespace CalcOperations.Starship.Business.Builders
{

    public static class StopCalculationResultBuilder
    {
        public static StopCalculationResult Build(StarshipResult starship, double distanceInMegaLights)
        {
            var result = new StopCalculationResult() { StarshipName = starship.Name };

            double starshipMegaLights;
            double.TryParse(starship.MGLT, out starshipMegaLights);

            if(starshipMegaLights == 0 || starship.Consumables == "unknown")
            {
                result.TotalStops = 0;
            }
            else{
                var hours = distanceInMegaLights / starshipMegaLights;
                var consumables = starship.Consumables.ToHours();
                var stops = consumables == 0 ? consumables : hours / consumables;
                result.TotalStops = Math.Floor(stops);
            }

            return result;
        }

    }

}