using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Service
{
    public class CityService : ICityServices
    {
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
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1/clima/previsao/{id}");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            throw new NotImplementedException();
        }

        static async Task<City> GetProductAsync(string path)
        {
            Product product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }
        public Task<City> GetCityByNameAsync(string name)
        {
            throw new NotImplementedException();
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
