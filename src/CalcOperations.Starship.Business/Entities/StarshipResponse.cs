using System.Collections.Generic;

namespace CalcOperations.Starship.Business.Entities
{
    public class StarshipResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public IList<StarshipResult> Results { get; set; }
    }
}