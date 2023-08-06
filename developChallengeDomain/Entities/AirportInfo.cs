using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Entities
{
    public class AirportInfo
    {

        public string? IATA { get; set; }
        public string? ICAO { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CityName { get; set; }
        public string? StateCode { get; set; }

        public AirportInfo()
        {
            
        }
    }
}
