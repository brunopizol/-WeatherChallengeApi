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
        Task AddAsync(City city);
        void Update(City city);
        void Delete(City city);
        Task<bool> SaveChangesAsync();
    }
}
