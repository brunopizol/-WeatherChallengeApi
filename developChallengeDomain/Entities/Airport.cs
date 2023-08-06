using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        public string? CodigoIcao { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public float PressaoAtmosferica { get; set; }
        public string Visibilidade { get; set; }
        public int Vento { get; set; }
        public int DirecaoVento { get; set; }
        public int Umidade { get; set; }
        public string? Condicao { get; set; }
        public string? CondicaoDesc { get; set; }
        public int Temperatura { get; set; }

    }
}
