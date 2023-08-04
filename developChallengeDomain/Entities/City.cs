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
        public string? CEP { get; set; }
        public string? CityName { get; set; }
        public int temperature { get; set; }


        #endregion
    }
}
