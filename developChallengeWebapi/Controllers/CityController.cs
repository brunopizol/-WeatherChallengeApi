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
        #endregion
        #region Constructors
        public cityController(ICityServices cityServices)
        {
            _CityServices = cityServices;
        }
        #endregion

        #region Actions
        [HttpGet("[action]")]
        public async Task<IEnumerable<City>> ListAsync()
        {
            return await _CityServices.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _CityServices.GetCityByIdAsync(id);
        }

        [HttpGet("{cep}")]
        public async Task<City> GetCityByCepAsync(int cep)
        {
            return await _CityServices.GetCityByCepAsync(cep);
        }

        [HttpGet("{name}")]
        public async Task<City> GetCityByNameAsync(string name)
        {
            return await _CityServices.GetCityByNameAsync(name);
        }
        #endregion
    }
}
