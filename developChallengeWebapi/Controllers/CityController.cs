using Microsoft.AspNetCore.Mvc;
using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Services;

namespace developChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class cityController : ControllerBase
    {
        #region Variables
        private readonly ICityServices _CityServices;
        private readonly ILogger<cityController> _logger;
        #endregion
        #region Constructors
        public cityController(ICityServices cityServices, ILogger<cityController> logger)
        {
            _CityServices = cityServices;
            _logger = logger;
        }
        #endregion

        #region Actions


        [HttpGet("[action]")]
        public async Task<IEnumerable<City>> GetCityByIdAsync(int id)
        {
            _logger.LogInformation("Received a GET request. [GetCityByIdAsync]");
            return await _CityServices.GetCityByIdAsync(id);
        }


        [HttpGet("[action]")]
        public async Task<IEnumerable<City>> GetCityByNameAsync(string name)
        {
            _logger.LogInformation("Received a GET request. [GetCityByNameAsync]");
            return await _CityServices.GetCityByNameAsync(name);
        }
        #endregion
    }
}
