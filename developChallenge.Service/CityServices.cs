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
using developChallenge.Service.Helpers;
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

        public async Task<List<City>> GetCityByIdAsync(int id)
        {
            List<City> cityList = new List<City>();
            try
            {           
                    _worker.Log(" make request GET: GetCityByIdAsync - DATA: " + id);
                    using (var response = _client.GetAsync($"v1/clima/previsao/{id}").Result)

                        if (response.IsSuccessStatusCode)
                        {

                            var settings = new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                PreserveReferencesHandling = PreserveReferencesHandling.All,
                                MaxDepth = 64 
                            };
                            var content = await response.Content.ReadAsStringAsync();
                            var cityDto = JsonConvert.DeserializeObject<CityClimateInfoDTO>(content, settings);
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
                            cityList.Add(city);
                            string jsonString = System.Text.Json.JsonSerializer.Serialize(city);
                            _worker.Log(" make request GET: GetCityByIdAsync - RESULT: " + jsonString);

                        }
                        else
                        {


                            await _loggerRepository.AddLogAsync(new Log
                            {
                                Action = "CityRepository - GetCityByIdAsync",
                                CreatedAt = DateTime.Now,
                                Description = "error on reponse: " + response.IsSuccessStatusCode,
                                status = "Error"
                            });
                            _worker.Log(" make request GET: GetCityByIdAsync - ERROR: " + response);
                            return null;

                        }
                    await _cityRepository.AddAsync(cityList);
                return cityList;
            }catch(Exception ex)
             {
                _worker.Log(" ERROR - " + ex.Message);
                await _loggerRepository.AddLogAsync(new Log
                {
                    Action = "CityRepository - GetCityByIdAsync",
                    CreatedAt = DateTime.Now,
                    Description = ex.Message,
                    status = "Error"
                });

                return new CityResult
                {
                    IsSuccess = false,
                    ErrorMessage = "An error occurred",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }

            public async Task<List<City>> GetCityByIdAsync(List<City> cities)
        {
            List<City> cityList = new List<City>();
            try
            {
                           
                foreach (City cityId in cities)
                {
                    _worker.Log(" make request GET: GetCityByIdAsync - DATA: " + cityId.cityId);
                    using (var response = _client.GetAsync($"v1/clima/previsao/{cityId.cityId}").Result)

                        if (response.IsSuccessStatusCode)
                        {

                            var settings = new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore, 
                                PreserveReferencesHandling = PreserveReferencesHandling.All,
                                MaxDepth = 64 
                            };
                            var content = await response.Content.ReadAsStringAsync();
                            var cityDto = JsonConvert.DeserializeObject<CityClimateInfoDTO>(content, settings);

                            var city = new City
                            {
                                CityName = cityDto.cidade,
                                clima = new Weather
                                {

                                    Condition = cityDto.Clima.FirstOrDefault()?.Condicao,
                                    Condition_desc = cityDto.Clima.FirstOrDefault()?.Condicao_desc,
                                    UVIndice = cityDto.Clima.FirstOrDefault().Indice_uv,
                                    MaxTemperature = cityDto.Clima.FirstOrDefault().Max,
                                    MinTemperature = cityDto.Clima.FirstOrDefault().Min,
                                    Date = cityDto.Clima.FirstOrDefault().Data,

                                },
                                StateCode = cityDto.estado,
                                UpdatedAt = cityDto.atualizado_em,
                                cityId = cityId.cityId
                            };
                            cityList.Add(city);
                            string jsonString = System.Text.Json.JsonSerializer.Serialize(city);
                            _worker.Log(" make request GET: GetCityByIdAsync - RESULT: " + jsonString);
                            
                        }
                        else
                        {


                            await _loggerRepository.AddLogAsync(new Log
                            {
                                Action = "CityRepository - GetCityByIdAsync",
                                CreatedAt = DateTime.Now,
                                Description = "error on reponse: " + response.IsSuccessStatusCode,
                                status = "Error"
                            });
                            _worker.Log(" make request GET: GetCityByIdAsync - ERROR: " + response);
                            return new CityResult
                            {
                                IsSuccess = false,
                                ErrorMessage = "Error in response",
                                StatusCode = response.StatusCode
                            };
                        }
                }
                await _cityRepository.AddAsync(cityList);
                  return cityList;
                
            }
            catch (Exception ex)
            {

                 _worker.Log(" ERROR - "+ex.Message);
                await _loggerRepository.AddLogAsync(new Log
                {
                    Action = "CityRepository - GetCityByIdAsync",
                    CreatedAt = DateTime.Now,
                    Description = ex.Message,
                    status = "Error"
                });

                throw;
            }

        }

        public async Task<IEnumerable<City>> GetCityByNameAsync(string name)
        {
            try
            {
                _worker.Log(" make request GET: GetCityByNameAsync - DATA: " + name);
                Console.WriteLine(" make request GET: GetCityByNameAsync - DATA: " + name);
                List<City> cities = new List<City>();
                
                using (var response = _client.GetAsync($"v1/cidade/{name}").Result)
                    if (response.IsSuccessStatusCode)
                {

                        var settings = new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore, 
                            PreserveReferencesHandling = PreserveReferencesHandling.All,
                            MaxDepth = 64 
                        };
                        var content = await response.Content.ReadAsStringAsync();
                        var cityDTOList = JsonConvert.DeserializeObject<List<Cidade>>(content, settings);

                        if (cityDTOList.Count()==0)
                            throw new HttpRequestException("City not found on database", null, HttpStatusCode.NotFound);

                        foreach (var cityDTO in cityDTOList)
                        {                            
                            var city = new City
                            {
                                CityName = cityDTO.nome, 
                                clima = new Weather
                                {
                                    Date = new DateTime(),
                                    Condition = "",
                                    MinTemperature = 0,
                                    MaxTemperature =0,
                                    UVIndice = 0,
                                    Condition_desc = "",
                                },
                                StateCode = cityDTO.estado,
                                UpdatedAt = new DateTime(),
                                cityId = cityDTO.id
                            };

                            cities.Add(city);
                        }
                        cities= (await this.GetCityByIdAsync(cities));
                        _worker.Log(" make request GET: GetCityByNameAsync - RESULT: " + cities);

                        return cities;
                    }
                else
                {
       
                    _worker.Log(" make request GET: GetCityByNameAsync - ERROR: " + response);
                    await _loggerRepository.AddLogAsync(new Log
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

                
                await _loggerRepository.AddLogAsync(new Log
                {
                    Action = "CityRepository - GetCityByNameAsync",
                    CreatedAt = DateTime.Now,
                    Description = ex.Message,
                    status = "Error"
                });
                return new CityResult
                {
                    IsSuccess = false,
                    ErrorMessage = "An error occurred",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

        }

       

    }
}
