using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Entities
{
    public class Clima
    {
        public DateTime Data { get; set; }
        public string? Condicao { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public float Indice_uv { get; set; }
        public float Condicao_desc { get; set; }
        public virtual City City { get; set; }
        public int CityId { get; set; }
    }
}
