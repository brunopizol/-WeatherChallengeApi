using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace developChallenge.Service.DTOs
{
    [XmlRoot(ElementName = "cidades", Namespace = "")]
    public class CityDTO
    {
        [XmlElement(ElementName = "cidade")]
        public List<Cidade> Cidades { get; set; }
    }
    public class Cidade
    {
        public string nome { get; set; }
        public string uf { get; set; }
        public int id { get; set; }

    }

}
