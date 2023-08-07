using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Domain.Interfaces.Services;
using developChallenge.Service.DTOs;
using Newtonsoft.Json;
using Worker;

namespace developChallenge.Service
{
    public class CityServices : ICityServices
    {
        private readonly HttpClient _client;
        private readonly ConsoleLogger _worker;

        public CityServices(HttpClient client, IAirportInfoRepository airportInfoRepository)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1");
            _worker = new ConsoleLogger();

        }
        public Task<City> GetCityByCepAsync(int cep)
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            try
            {
                _worker.Log(" make request GET: GetCityByIdAsync - DATA: "+ id);                
                using (var response = await _client.GetAsync($"v1/clima/previsao/{id}"))

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var cityDto = JsonConvert.DeserializeObject<CityClimateInfoDTO>(content);

                        // Convert AirportDto to Airport
                        var city = new City
                        {
                            CityName = cityDto.cidade,
                            clima = new Weather
                            {
                                
                                    Condition = cityDto.Clima.FirstOrDefault().Condicao,
                                    Condition_desc = cityDto.Clima.FirstOrDefault().Condicao_desc,
                                    UVIndice = cityDto.Clima.FirstOrDefault().Indice_uv,
                                    MaxTemperature = cityDto.Clima.FirstOrDefault().Max,
                                    MinTemperature = cityDto.Clima.FirstOrDefault().Min,
                                    Date = cityDto.Clima.FirstOrDefault().Data,                             
                                
                            },
                            StateCode = cityDto.estado,
                            UpdatedAt = cityDto.atualizado_em
                        };

                        string jsonString = System.Text.Json.JsonSerializer.Serialize(city);
                        _worker.Log(" make request GET: GetCityByIdAsync - RESULT: " + jsonString);
                        return city;
                    }
                    else
                    {
                        // Lidar com o caso em que a solicitação não foi bem-sucedida (por exemplo, erro 404, 500, etc.).
                        // Retornar nulo ou lançar uma exceção, dependendo do comportamento desejado.
                        _worker.Log(" make request GET: GetCityByIdAsync - ERROR: " + response);
                        return null;
                    }
            }
            catch (Exception ex)
            {
                _worker.Log(" ERROR - "+ex.Message);
                // Lidar com exceções que possam ocorrer durante a solicitação HTTP.
                // Retornar nulo ou lançar uma exceção, dependendo do comportamento desejado.
                return null;
            }

        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            try
            {
                _worker.Log(" make request GET: GetCityByNameAsync - DATA: " + name);
                Console.WriteLine(" make request GET: GetCityByNameAsync - DATA: " + name);
                HttpClient _temporaryClient;
                _temporaryClient = new HttpClient();
                _temporaryClient.BaseAddress = new Uri("http://servicos.cptec.inpe.br/");
                var response = await _temporaryClient.GetAsync($"XML/listaCidades?city={Uri.EscapeDataString(name)}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var xmldoc = new XmlDocument();
                    xmldoc.LoadXml(content);
                    var fromXml = JsonConvert.SerializeXmlNode(xmldoc);

                    // Deserialize the XML response into CityDTO
                    var serializer = new XmlSerializer(typeof(CityDTO));
                    CityDTO cityDTO;
                    using (var stringReader = new StringReader(content))
                    {
                        cityDTO = (CityDTO)serializer.Deserialize(stringReader);
                    }

                    if (cityDTO == null || cityDTO.Cidades.FirstOrDefault().id == null)
                        return null;

                    // Access the properties of the cidade object within cityDTO

                    var result = await this.GetCityByIdAsync(cityDTO.Cidades.FirstOrDefault().id);
                    _worker.Log(" make request GET: GetCityByNameAsync - RESULT: " + result);
                    return result;
                }
                else
                {
                    // Lidar com o caso em que a solicitação não foi bem-sucedida (por exemplo, erro 404, 500, etc.).
                    // Retornar nulo ou lançar uma exceção, dependendo do comportamento desejado.
                    _worker.Log(" make request GET: GetCityByNameAsync - ERROR: " + response);
                    return null;
                }
            }
            catch (Exception ex)
            {
                _worker.Log(" ERROR - " + ex.Message);
                // Lidar com exceções que possam ocorrer durante a solicitação HTTP.
                // Retornar nulo ou lançar uma exceção, dependendo do comportamento desejado.
                return null;
            }

        }

       

    }
}
