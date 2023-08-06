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
        #endregion
        #region Constructors
        public AirportController(IAirportServices airportServices)
        {
            _AirportServices = airportServices;
        }
        #endregion

        #region Actions
        [HttpGet("[action]")]
        public async Task<IEnumerable<Airport>> ListAsync()
        {
            return await _AirportServices.GetListAsync();
        }

        [HttpGet("[action]")]
        public async Task<Airport> GetAirportByIdAsync(string id)
        {
            return await _AirportServices.GetAirportByIdAsync(id);
        }

        [HttpGet("[action]")]
        public async Task<Airport> GetAirportByNameAsync(string name)
        {
            return await _AirportServices.GetAirportByNameAsync(name);
        }
        #endregion
    }
}

