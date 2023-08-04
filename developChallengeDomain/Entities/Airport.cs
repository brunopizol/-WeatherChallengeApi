using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Entities
{
    public class Airport
    {
        #region properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public int temperature { get; set; }
        public City? City { get; set; }
        #endregion
    }
}
