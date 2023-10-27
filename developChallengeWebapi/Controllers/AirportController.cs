using Microsoft.AspNetCore.Mvc;
using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Services;

namespace developChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController : ControllerBase
    {
        #region Variables
        private readonly IAirportServices _AirportServices;
        private readonly ILogger<AirportController> _logger;
        #endregion
        #region Constructors
        public AirportController(IAirportServices airportServices, ILogger<AirportController> logger)
        {
            _AirportServices = airportServices;
            _logger = logger;
        }
        #endregion


        #region Methods
        [HttpGet("[action]")]
        public async Task<Airport> GetAirportByIdAsync(string id)
        {
            _logger.LogInformation("Received a GET request. [GetAirportByIdAsync]");
            return await _AirportServices.GetAirportByIdAsync(id);
        }

        [HttpGet("[action]")]
        public async Task<Airport> GetAirportByNameAsync(string name)
        {
            _logger.LogInformation("Received a GET request. [GetAirportByNameAsync]");
            return await _AirportServices.GetAirportByNameAsync(name);
        }
        #endregion
    }
}

