using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Transactions;

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
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                
                try
                {

                    _dbContext.Logs.Add(log);

                    var result = await _dbContext.SaveChangesAsync();
                    scope.Complete();
                    if (result > 0)
                    {
                        Console.WriteLine("Record inserted successfully.");                        
                        return true;

                    }
                   
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Exception(ex.Message);
                }
            }
            return false;


        }

    }
}
