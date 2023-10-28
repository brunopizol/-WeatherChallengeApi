using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Service;
using developChallenge.Web.Api.DTOs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Moq.Language.Flow;
using developChallenge.Service.Helpers;

namespace developChallenge.UnitTests.Services
{
    public class AirportServicesTests
    {
    

        [Fact]
        public async Task GetAirportByIdAsync_Success()
        {
            // Arrange
            string airportId = "SBSP";
            var airportDto = new AirportDTO
            {
                CodigoIcao = "SBSP",
                AtualizadoEm = DateTime.Now,
                // ... preencha outros campos do DTO
            };
            var expectedAirport = new Airport
            {
                CodigoIcao = airportDto.CodigoIcao,
                AtualizadoEm = airportDto.AtualizadoEm,
                // ... preencha outros campos do Airport
            };
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };

            var httpClient = new Mock<HttpClient>();
            //httpClient.Setup(c => c.GetAsync("https://brasilapi.com.br/api/cptec/v1")).ReturnsAsync(new HttpResponseMessage
            //{
            //    StatusCode = HttpStatusCode.OK,
            //    Content = new StringContent(JsonSerializer.Serialize(airportDto))
            //});

            var httpClientWrapper = new Mock<IHttpClientWrapper>();
            httpClientWrapper.Setup(c => c.GetAsync("https://brasilapi.com.br/api/cptec/v1")).ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(airportDto))
            });

            var airportInfoRepository = new Mock<IAirportInfoRepository>();
            airportInfoRepository.Setup(r => r.GetByNameAsync("congonhas")).Returns(new[] { new AirportInfo { ICAO = "ABC123" } });

            var logRepository = new Mock<ILoggerRepository>();
            var airportRepository = new Mock<IAirportRepository>();

            var airportServices = new AirportServices(httpClient.Object, airportInfoRepository.Object, logRepository.Object, airportRepository.Object);

            // Act
            var result = await airportServices.GetAirportByIdAsync(airportId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAirport.CodigoIcao, result.CodigoIcao);
            // Faça as asserções para outros campos, se necessário
        }

        [Fact]
        public async Task GetAirportByNameAsync_Success()
        {
            // Arrange
            string airportName = "congonhas";
            string airportId = "SBSP";

            var airportDto = new AirportDTO
            {
                CodigoIcao = airportId,
                AtualizadoEm = DateTime.Now,
                // ... preencha outros campos do DTO
            };

            var expectedAirport = new Airport
            {
                CodigoIcao = airportDto.CodigoIcao,
                AtualizadoEm = airportDto.AtualizadoEm,
                // ... preencha outros campos do Airport
            };
            var httpClient = new Mock<HttpClient>();
            var httpClientWrapper = new Mock<IHttpClientWrapper>();
            httpClientWrapper.Setup(c => c.GetAsync("https://brasilapi.com.br/api/cptec/v1")).ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(airportDto))
            });
            var airportInfoRepository = new Mock<IAirportInfoRepository>();
            airportInfoRepository.Setup(r => r.GetByNameAsync(airportName)).Returns(new[] { new AirportInfo { ICAO = airportId } });

            var logRepository = new Mock<ILoggerRepository>();
            var airportRepository = new Mock<IAirportRepository>();

            var airportServices = new AirportServices(httpClient.Object, airportInfoRepository.Object, logRepository.Object, airportRepository.Object);

            // Act
            var result = await airportServices.GetAirportByNameAsync(airportName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAirport.CodigoIcao, result.CodigoIcao);
            // Faça as asserções para outros campos, se necessário
        }

        [Fact]
        public async Task GetAirportByNameAsync_AirportNotFound()
        {
            // Arrange
            string airportName = "NonExistentAirport";

            var httpClient = new Mock<HttpClient>();
            var airportInfoRepository = new Mock<IAirportInfoRepository>();
            airportInfoRepository.Setup(r => r.GetByNameAsync(airportName)).Returns(new AirportInfo[] { }); // Use uma matriz vazia como exemplo



            var logRepository = new Mock<ILoggerRepository>();
            var airportRepository = new Mock<IAirportRepository>();

            var airportServices = new AirportServices(httpClient.Object, airportInfoRepository.Object, logRepository.Object, airportRepository.Object);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => airportServices.GetAirportByNameAsync(airportName));
        }
    }
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public HttpResponseMessage Response { get; set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Response);
        }
    }
}
