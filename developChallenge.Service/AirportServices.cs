using developChallenge.Domain.Entities;
using developChallenge.Infra.Repository;
using developChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using developChallenge.Web.Api.DTOs;
using developChallenge.Domain.Interfaces.Repository;
using Worker;
using System.Web;
using System.Net;

namespace developChallenge.Service
{
    public class AirportServices : IAirportServices
    {
        private readonly HttpClient _client;
        private readonly ConsoleLogger _worker;
        private readonly IAirportInfoRepository _airportInfoRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly ILoggerRepository _logRepository;

        public AirportServices(HttpClient client, IAirportInfoRepository airportInfoRepository, ILoggerRepository logRepository, IAirportRepository airportRepository)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1");
            _worker = new ConsoleLogger();
            _airportInfoRepository = airportInfoRepository ?? throw new ArgumentNullException(nameof(airportInfoRepository));
            _logRepository = logRepository;
            _airportRepository = airportRepository;
        }


        public async Task<Airport> GetAirportByIdAsync(string id)
        {
            try
            {
                _worker.Log(" make request GET: GetAirportByIdAsync - DATA: " + id);
                using (var response = await _client.GetAsync($"v1/clima/aeroporto/{id}"))

                    if (response.IsSuccessStatusCode)
                {
                        var content = await response.Content.ReadAsStringAsync();
                        var airportDto = JsonSerializer.Deserialize<AirportDTO>(content);
                        var airport = new Airport
                        {
                            CodigoIcao = airportDto.CodigoIcao,
                            AtualizadoEm = airportDto.AtualizadoEm,
                            PressaoAtmosferica = airportDto.PressaoAtmosferica,
                            Visibilidade = airportDto.Visibilidade,
                            Vento = airportDto.Vento,
                            DirecaoVento = airportDto.DirecaoVento,
                            Umidade = airportDto.Umidade,
                            Condicao = airportDto.Condicao,
                            CondicaoDesc = airportDto.CondicaoDesc,
                            Temperatura = airportDto.Temperatura
                        };
                        string strJson = JsonSerializer.Serialize(airport);
                        _worker.Log(" make request GET: GetAirportByIdAsync - RESULT: " + strJson);
                        await _logRepository.AddLogAsync(new Log
                        {
                            Description = strJson,
                            Action = "GetAirportByIdAsync",
                            status = "Success"
                        });
                        await _airportRepository.AddAsync(airport);
                        return airport;
                    }
                else
                {
                        string strJson = JsonSerializer.Serialize(response);
                        _worker.Log(" make request GET: GetAirportByIdAsync - ERROR: " + strJson);
                        await _logRepository.AddLogAsync(new Log
                        {
                            Description = strJson,
                            Action = "GetAirportByIdAsync",
                            status = "Error"
                        });
                        return null;
                }
            }
            catch (Exception ex)
            {
                _worker.Log(" make request GET: GetAirportByIdAsync - ERROR: " + ex.Message);
                await _logRepository.AddLogAsync(new Log
                {
                    Description = ex.Message,
                    Action = "GetAirportByIdAsync",
                    status = "Error"
                });
                return null;
            }

        }

        public async Task<Airport> GetAirportByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            try
            {
                _worker.Log(" make request GET: GetAirportByNameAsync - DATA: " + name);
                var result = _airportInfoRepository.GetByNameAsync(name);
                if(result == null || result.Count()==0)
                {
                    _worker.Log(" make request GET: GetAirportByNameAsync - ERROR: " + "airport not found on database");
                    await _logRepository.AddLogAsync(new Log
                    {
                        Description = "airport not found on database",
                        Action = "GetAirportByNameAsync",
                        status = "Error"
                    });
                    throw new HttpRequestException("airport not found on database", null, HttpStatusCode.NotFound);
                }
                string strJson = JsonSerializer.Serialize(result);
                await _logRepository.AddLogAsync(new Log
                {
                    Description = strJson,
                    Action = "GetAirportByNameAsync",
                    status = "Success"
                });                
                return await this.GetAirportByIdAsync(result.First().ICAO);


            }
            catch (Exception ex)
            {
                _worker.Log(" make request GET: GetAirportByNameAsync - ERROR: " + ex.Message);
                await _logRepository.AddLogAsync(new Log
                {
                    Description = ex.Message,
                    Action = "GetAirportByNameAsync",
                    status = "Error"
                });
                throw;
            }
            
        }

    }
}
