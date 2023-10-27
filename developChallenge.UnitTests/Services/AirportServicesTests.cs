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

namespace developChallenge.UnitTests.Services
{
    public class AirportServicesTests
    {
        [Fact]
        public async Task GetAirportByIdAsync_ReturnsAirport()
        {
            // Arrange
            var mockAirportRepository = new Mock<IAirportRepository>();
            var mockAirportInfoRepository = new Mock<IAirportInfoRepository>();
            var mockLogRepository = new Mock<ILoggerRepository>();
            var httpClient = new HttpClient(new FakeHttpMessageHandler());
            var airportServices = new AirportServices(httpClient, mockAirportInfoRepository.Object, mockLogRepository.Object, mockAirportRepository.Object);
            var airportId = "ABC123";
            var airportDto = new AirportDTO
            {
                CodigoIcao = "ABC123",
                AtualizadoEm = DateTime.Now,
                PressaoAtmosferica = 1015.2F, 
                Visibilidade = "10000", 
                Vento = 10, 
                DirecaoVento = 90, 
                Umidade = 70, 
                Condicao = "Céu Limpo", 
                CondicaoDesc = "Céu claro e ensolarado.",
                Temperatura = 25
            };
            var expectedAirport = new Airport
            {
                CodigoIcao = "ABC123",
                AtualizadoEm = DateTime.Now,
                PressaoAtmosferica = 1015.2F,
                Visibilidade = "1000", 
                Vento = 10, 
                DirecaoVento = 90, 
                Umidade = 70, 
                Condicao = "Céu Limpo", 
                CondicaoDesc = "Céu claro e ensolarado.", 
                Temperatura = 25
            };
            httpClient.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1");
            var fakeResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(airportDto))
            };
            var fakeHttpMessageHandler = new FakeHttpMessageHandler { Response = fakeResponseMessage };
            httpClient = new HttpClient(fakeHttpMessageHandler);
            mockAirportRepository.Setup(repo => repo.AddAsync(expectedAirport));

            // Act
            var result = await airportServices.GetAirportByIdAsync(airportId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAirport.CodigoIcao, result.CodigoIcao);
            // Defina outras asserções para os campos do Airport

            mockAirportRepository.Verify(repo => repo.AddAsync(expectedAirport), Times.Once);
        }

        [Fact]
        public async Task GetAirportByNameAsync_ReturnsAirport()
        {
            // Arrange
            var mockAirportRepository = new Mock<IAirportRepository>();
            var mockAirportInfoRepository = new Mock<IAirportInfoRepository>();
            var mockLogRepository = new Mock<ILoggerRepository>();
            var httpClient = new HttpClient(new FakeHttpMessageHandler());
            var airportServices = new AirportServices(httpClient, mockAirportInfoRepository.Object, mockLogRepository.Object, mockAirportRepository.Object);
            var airportName = "SampleAirportName";
            var airportInfo = new List<AirportInfo>
            {
                // Crie objetos AirportInfo de exemplo aqui
            };
            var airportDto = new AirportDTO
            {
                CodigoIcao = "ABC123",
                AtualizadoEm = DateTime.Now,
                // Defina outros campos do DTO
            };
            var expectedAirport = new Airport
            {
                CodigoIcao = "ABC123",
                AtualizadoEm = DateTime.Now,
                // Defina outros campos do Airport
            };
            mockAirportInfoRepository
            .Setup(repo => repo.GetByNameAsync(It.IsAny<string>()))
            .Returns((string name) => Task.FromResult(new List<AirportInfo>
            {
                new AirportInfo
                {                    
                    IATA = "ABC",
                    ICAO = "ABC123",
                    Name = "Airport1",
                    Description = "Description1",
                    CityName = "City1",
                    StateCode = "State1"
                }
            }));

            httpClient.BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1");
            var fakeResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(airportDto))
            };
            var fakeHttpMessageHandler = new FakeHttpMessageHandler { Response = fakeResponseMessage };
            httpClient = new HttpClient(fakeHttpMessageHandler);
            mockAirportRepository.Setup(repo => repo.AddAsync(expectedAirport));

            // Act
            var result = await airportServices.GetAirportByNameAsync(airportName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAirport.CodigoIcao, result.CodigoIcao);
            // Defina outras asserções para os campos do Airport

            mockAirportInfoRepository.Verify(repo => repo.GetByNameAsync(airportName), Times.Once);
            mockAirportRepository.Verify(repo => repo.AddAsync(expectedAirport), Times.Once);
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
