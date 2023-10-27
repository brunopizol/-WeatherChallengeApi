using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Entities
{
    public class City
    {
        #region properties
        public int Id { get; set; }
        public int cityId { get; set; }
        public string? CityName { get; set; }
        public string? StateCode { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Weather clima { get; set; }


        #endregion
    }
}
