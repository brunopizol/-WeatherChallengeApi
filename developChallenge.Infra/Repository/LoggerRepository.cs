using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Infra.Repository
{
    public class LoggerRepository : ILoggerRepository
    {
        private readonly MyDatabaseContext _dbContext;

        public LoggerRepository(MyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddLogAsync(Log log)
        {
            log.CreatedAt = DateTime.UtcNow;

            
            _dbContext.Logs.Add(log);
            var result = await _dbContext.SaveChangesAsync();
            if (result == 1)
            {
                return true;

            }

            return false;

        }

        public Task<Log> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
