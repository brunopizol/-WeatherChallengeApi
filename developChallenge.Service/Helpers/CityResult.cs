using developChallenge.Domain.Entities;
using developChallenge.Service.DTOs;
using System.Net;

namespace developChallenge.Service.Helpers
{
    public class CityResult : List<City>
    {
        public bool IsSuccess { get; set; }
        public List<Cidade> Cities { get; set; }
        public string ErrorMessage { get; internal set; }
        public HttpStatusCode StatusCode { get; internal set; }
    }
}