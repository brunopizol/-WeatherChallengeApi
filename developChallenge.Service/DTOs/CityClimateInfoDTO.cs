using developChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Service.DTOs
{
    public class CityClimateInfoDTO
    {
        #region properties
        
        public string? cidade { get; set; }
        public string? estado { get; set; }
        public DateTime atualizado_em { get; set; }
        public List<weatherDTO>? Clima { get; set; }
        #endregion
    }

    public class weatherDTO
    {

        public DateTime Data { get; set; }
        public string? Condicao { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public float Indice_uv { get; set; }
        public string Condicao_desc { get; set; }

    }
}
