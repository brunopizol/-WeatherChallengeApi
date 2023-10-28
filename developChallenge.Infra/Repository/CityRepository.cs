using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
        public async Task<bool> AddAsync(List<City> city)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (City cityItem in city)
                    {

                        _dbContext.Cities.Add(cityItem);
                    }
                    var result = await _dbContext.SaveChangesAsync();
                    scope.Complete();
                    if (result >0)
                    {
                        await _loggerRepository.AddLogAsync(new Log
                        {
                            Action = "CityRepository - AddAsync",
                            CreatedAt = DateTime.Now,
                            Description = "Adding city to database",
                            status = "Success"
                        });
                        return true;

                    }

                    await _loggerRepository.AddLogAsync(new Log
                    {
                        Action = "CityRepository - AddAsync",
                        CreatedAt = DateTime.Now,
                        Description = "Adding airport to database",
                        status = "Error"
                    });
                    return false;
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    await _loggerRepository.AddLogAsync(new Log
                    {
                        Action = "CityRepository - AddAsync",
                        CreatedAt = DateTime.Now,
                        Description = " ERROR: " + ex.Message,
                        status = "Error"
                    });
                    throw;
                }
            }
        }

       
    }
}
