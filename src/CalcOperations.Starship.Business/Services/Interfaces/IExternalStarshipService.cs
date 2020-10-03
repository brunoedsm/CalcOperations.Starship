using System.Collections.Generic;
using System.Threading.Tasks;
using CalcOperations.Starship.Business.Entities;

namespace CalcOperations.Starship.Business.Services.Interfaces
{

    public interface IExternalStarshipService
    {
       Task<List<StarshipResult>> GetAll();
    }

}