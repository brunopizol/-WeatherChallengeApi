using developChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Interfaces.Services
{
    public interface ICityServices
    {
        Task<IEnumerable<City>> GetListAsync();
        Task<City> GetAsync(int id);
        Task<City> GetCityByIdAsync(int id);
        Task<City> GetCityByCepAsync(int cep);
        Task<City> GetCityByNameAsync(string name);
        Task AddAsync(City city);
        void Update(City city);
        void Delete(City city);
        Task<bool> SaveChangesAsync();
    }
}
