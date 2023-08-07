using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace developChallenge.Domain.Entities
{
    public class Weather
    {        
        public DateTime Date { get; set; }
        public string? Condition { get; set; }
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public float UVIndice { get; set; }
        public string Condition_desc { get; set; }
        [JsonIgnore]
        public virtual City City { get; set; }
        public int CityId { get; set; }


        public Weather()
        {
            this.City = new City();
        }


    }
}
