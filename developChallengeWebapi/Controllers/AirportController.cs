using Microsoft.AspNetCore.Mvc;
using developChallenge.Domain.Services;

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
        public CategoryController(IAirportServices categoryServices)
        {
            _AirportServices = categoryServices;
        }
        #endregion

        #region Actions
        [HttpGet("[action]")]
        public async Task<IEnumerable<Airport>> ListAsync()
        {
            return await _AirportServices.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Airport> GetAsync(int id)
        {
            return await _AirportServices.GetAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddAsync([FromBody] Airport airport)
        {
            return await _AirportServices.AddAsync(airport);
        }

        [HttpPut]
        public async Task<bool> UpdateAsync([FromBody] Airport airport)
        {
            return await _AirportServices.UpdateAsync(airport);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _AirportServices.DeleteAsync(id);
        }
        #endregion
    }
}
}
