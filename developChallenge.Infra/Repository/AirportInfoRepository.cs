using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using developChallenge.Infra.Context;



namespace developChallenge.Infra.Repository
{
    public class AirportInfoRepository : IAirportInfoRepository
    {
        private readonly MyDatabaseContext _dbContext;
        //private readonly LoggerRepository _loggerRepository;


        public AirportInfoRepository(MyDatabaseContext dbContext
                                  )
        {
            _dbContext = dbContext;
            
        }

        public IEnumerable<AirportInfo> GetByNameAsync(string name)
        {

            try
            {
                return _dbContext.AirportsInfos
                  .AsEnumerable()
                  .Where(ai => ai.Name.Contains(name, StringComparison.OrdinalIgnoreCase)
                                || (ai.Description != null && ai.Description.Contains(name, StringComparison.OrdinalIgnoreCase)))
                  .ToList();
            
            }
            catch (Exception ex)
            {
                //_loggerRepository.AddAsync(new Log
                //{
                //    Action = "Task<AirportInfo> GetByNameAsync",
                //    DescriptionError = ex.Message,

                //});
                throw;
            }
        }
    }
}
