using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Infra.Repository
{
    public class LoggerRepository : ILoggerRepository
    {
        public Task AddAsync(Log log)
        {
            throw new NotImplementedException();
        }

        public Task<Log> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
