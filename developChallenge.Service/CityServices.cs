using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Services;

namespace developChallenge.Service
{
    public class CityServices : ICityServices
    {
        private readonly HttpClient _client;

        public CityServices()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1");
        }
        public Task AddAsync(City city)
        {
            throw new NotImplementedException();
        }

        public void Delete(City city)
        {
            throw new NotImplementedException();
        }

        public Task<City> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<City> GetCityByCepAsync(int cep)
        {
            throw new NotImplementedException();
        }

        public Task<City> GetCityByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            try
            {
                var response = await _client.GetAsync($"/clima/aeroporto/{name}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<City>(content);
                    return result;
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

        public Task<IEnumerable<City>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(City city)
        {
            throw new NotImplementedException();
        }
      

    }
}
