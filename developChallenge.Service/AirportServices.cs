using developChallenge.Domain.Entities;
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

namespace developChallenge.Service
{
    public class AirportServices : IAirportServices
    {
        private readonly HttpClient _client;

        public AirportServices()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1");
        }

        public Task AddAsync(Airport airport)
        {
            throw new NotImplementedException();
        }

        public void Delete(Airport airport)
        {
            throw new NotImplementedException();
        }

        public async Task<Airport> GetAirportByIdAsync(string id)
        {
            try
            {
                using (var response = await _client.GetAsync($"v1/clima/aeroporto/{id}"))

                    if (response.IsSuccessStatusCode)
                {
                        var content = await response.Content.ReadAsStringAsync();
                        var airportDto = JsonSerializer.Deserialize<AirportDTO>(content);

                        // Convert AirportDto to Airport
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

                        return airport;
                    }
                else
                {
                    // Lidar com o caso em que a solicitação não foi bem-sucedida (por exemplo, erro 404, 500, etc.).
                    // Retornar nulo ou lançar uma exceção, dependendo do comportamento desejado.
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções que possam ocorrer durante a solicitação HTTP.
                // Retornar nulo ou lançar uma exceção, dependendo do comportamento desejado.
                return null;
            }

        }

        public Task<Airport> GetAirportByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Airport> GetAirportByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Airport> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Airport>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Airport airport)
        {
            throw new NotImplementedException();
        }
    }
}
