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
    public class CityRepository : ICityRepository
    {
        private readonly MyDatabaseContext _dbContext;
        private readonly ILoggerRepository _loggerRepository;


        public CityRepository(MyDatabaseContext dbContext,
            ILoggerRepository loggerRepository
                                  )
        {
            _dbContext = dbContext;
            _loggerRepository = loggerRepository;

        }
        public async Task<bool> AddAsync(City city)
        {
            try
            {
                _dbContext.Cities.Add(city);
                var result = _dbContext.SaveChangesAsync().Result;
                if (result == 2)
                {
                    _loggerRepository.AddLogAsync(new Log
                    {
                        Action = "CityRepository - AddAsync",
                        CreatedAt = DateTime.Now,
                        Description = "Adding city to database",
                        status = "Success"
                    });
                    return true;

                }
                _loggerRepository.AddLogAsync(new Log
                {
                    Action = "CityRepository - AddAsync",
                    CreatedAt = DateTime.Now,
                    Description = "Adding airport to database",
                    status = "Error"
                });
                return false;
            }catch(Exception ex)
            {
                _loggerRepository.AddLogAsync(new Log
                {
                    Action = "CityRepository - AddAsync",
                    CreatedAt = DateTime.Now,
                    Description = " ERROR: " + ex.Message,
                    status = "Error"
                });
                throw ex;
            }
        }

       
    }
}
