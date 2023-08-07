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
        Task<Airport> GetAirportByIdAsync(string id);
        Task<Airport> GetAirportByNameAsync(string name);

    }
}
