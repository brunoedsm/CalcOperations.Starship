using System.Collections.Generic;
using CalcOperations.Starship.Business.Entities;

namespace CalcOperations.Starship.Business.Services.Interfaces
{

    public interface IStopCalculationService
    {
       List<StarshipResult> GetAll();
    }

}