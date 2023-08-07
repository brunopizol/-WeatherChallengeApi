using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        private readonly ICityRepository _cityRepository;
        private ILoggerRepository _loggerRepository;

        public CityServices(HttpClient client, IAirportInfoRepository airportInfoRepository, ICityRepository cityRepository, ILoggerRepository loggerRepository)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1");
            _worker = new ConsoleLogger();
            _cityRepository = cityRepository;
            _loggerRepository = loggerRepository;
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
                using (var response = _client.GetAsync($"v1/clima/previsao/{id}").Result)

                    if (response.IsSuccessStatusCode)
                    {

                        var settings = new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore, // This setting ignores object cycles
                            PreserveReferencesHandling = PreserveReferencesHandling.All,
                            MaxDepth = 64 // Adjust the depth to your needs, default is 32
                        };
                        var content = await response.Content.ReadAsStringAsync();
                        var cityDto = JsonConvert.DeserializeObject<CityClimateInfoDTO>(content, settings);

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
                        _cityRepository.AddAsync(city);
                        return city;
                    }
                    else
                    {


                        _loggerRepository.AddLogAsync(new Log
                        {
                            Action = "CityRepository - GetCityByIdAsync",
                            CreatedAt = DateTime.Now,
                            Description = "error on reponse: "+response.IsSuccessStatusCode,
                            status = "Error"
                        });
                        _worker.Log(" make request GET: GetCityByIdAsync - ERROR: " + response);
                        return null;
                    }
            }
            catch (Exception ex)
            {

                _worker.Log(" ERROR - "+ex.Message);
                _loggerRepository.AddLogAsync(new Log
                {
                    Action = "CityRepository - GetCityByIdAsync",
                    CreatedAt = DateTime.Now,
                    Description = ex.Message,
                    status = "Error"
                });
                
                throw ex;
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
                var response =  _temporaryClient.GetAsync($"XML/listaCidades?city={Uri.EscapeDataString(name)}").Result;

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

                    if (cityDTO == null || cityDTO.Cidades.Count()==0)
                        throw new HttpRequestException("City not found on database", null, HttpStatusCode.NotFound);

                    // Access the properties of the cidade object within cityDTO

                    var result = this.GetCityByIdAsync(cityDTO.Cidades.FirstOrDefault().id).Result;
                    _worker.Log(" make request GET: GetCityByNameAsync - RESULT: " + result);
                    return result;
                }
                else
                {
       
                    _worker.Log(" make request GET: GetCityByNameAsync - ERROR: " + response);
                    _loggerRepository.AddLogAsync(new Log
                    {
                        Action = "CityRepository - GetCityByNameAsync",
                        CreatedAt = DateTime.Now,
                        Description = "error on reponse: " + response.IsSuccessStatusCode,
                        status = "Error"
                    });
                    return null;
                }
            }
            catch (Exception ex)
            {
                _worker.Log(" ERROR - " + ex.Message);

                
                _loggerRepository.AddLogAsync(new Log
                {
                    Action = "CityRepository - GetCityByNameAsync",
                    CreatedAt = DateTime.Now,
                    Description = ex.Message,
                    status = "Error"
                });
                return null;
            }

        }

       

    }
}
