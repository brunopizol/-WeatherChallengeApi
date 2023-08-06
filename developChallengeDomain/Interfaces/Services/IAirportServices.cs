using developChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Interfaces.Services
{
    public interface IAirportServices
    {
        Task<IEnumerable<Airport>> GetListAsync();
        Task<Airport> GetAsync(int id);
        Task<Airport> GetAirportByIdAsync(string id);
        Task<Airport> GetAirportByNameAsync(string name);
        Task AddAsync(Airport airport);
        void Update(Airport airport);
        void Delete(Airport airport);
        Task<bool> SaveChangesAsync();
    }
}
