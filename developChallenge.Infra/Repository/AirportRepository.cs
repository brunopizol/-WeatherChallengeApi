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
    public class AirportRepository : IAirportRepository

    {
        private readonly MyDatabaseContext _dbContext;
        private readonly ILoggerRepository _loggerRepository;


        public AirportRepository(MyDatabaseContext dbContext,ILoggerRepository loggerRepository
                                  )
        {
            _dbContext = dbContext;
            _loggerRepository = loggerRepository;

        }
        public async Task<bool> AddAsync(Airport airport)
        {
            try
            {
                _dbContext.Airports.Add(airport);
                var result = await _dbContext.SaveChangesAsync();
                if (result == 1)
                {
                    await _loggerRepository.AddLogAsync(new Log
                    {
                        Action = "AirportRepository - AddAsync",
                        CreatedAt = DateTime.Now,
                        Description = "Adding airport to database",
                        status = "Success"
                    });
                    return true;

                }

                await _loggerRepository.AddLogAsync(new Log
                {
                    Action = "AirportRepository - AddAsync",
                    CreatedAt = DateTime.Now,
                    Description = "Adding airport to database",
                    status = "Error"
                });
                return false;
            }catch(Exception ex)
            {

                await _loggerRepository.AddLogAsync(new Log
                {
                    Action = "AirportRepository - AddAsync",
                    CreatedAt = DateTime.Now,
                    Description = "Adding airport to database",
                    status = "Error"
                });
                throw ex;
            }
        }

      
    }
}
