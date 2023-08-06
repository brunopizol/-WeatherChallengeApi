using developChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Domain.Interfaces.Repository
{
    public interface ILoggerRepository
    {
        Task<Log> GetAsync(int id);
        Task AddAsync(Log log);
    }
}
