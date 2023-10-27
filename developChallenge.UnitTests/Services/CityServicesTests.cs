using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Domain.Entities;
using developChallenge.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using developChallenge.UnitTests.Services;
using developChallenge.Service.DTOs;
using Newtonsoft.Json;
using developChallenge.Web.Api.DTOs;
using System.Text.Json;
using System.Net.Http.Headers;
using developChallenge.Domain.Interfaces.Services;

namespace developChallenge.UnitTests;
public class CityServicesTests
{
    [Fact]
    public async Task GetCityByIdAsync_SingleCity_Success()
    {
        // Arrange
        var httpClient = new HttpClient(new FakeHttpMessageHandler());
        var mockCityRepository = new Mock<ICityRepository>();
        var mockLoggerRepository = new Mock<ILoggerRepository>();
        var mockAirportInfoRepository = new Mock<IAirportInfoRepository>();
        var cityServices = new CityServices(httpClient, mockAirportInfoRepository.Object, mockCityRepository.Object, mockLoggerRepository.Object);
        var mockCityServices = new Mock<ICityServices>();

        var cityId = 123;
        var cityDto = new CityClimateInfoDTO
        {
            cidade = "passos",
            estado = "mg",
            atualizado_em = new DateTime(),
            Clima = new List<weatherDTO>
            {
                new weatherDTO
                {
                    Data = new DateTime(),
                    Condicao = "n",
                    Min = 16,
                    Max = 27,
                    Indice_uv = 12,
                    Condicao_desc = "nublado"
                }
            }
        };
        var fakeResponseMessage = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonConvert.SerializeObject(cityDto))
        };
        var fakeHttpMessageHandler = new FakeHttpMessageHandler { Response = fakeResponseMessage };
        httpClient = new HttpClient(fakeHttpMessageHandler);

        List<City> capturedCities = null;
        mockCityRepository.Setup(repo => repo.AddAsync(It.IsAny<List<City>>())).Callback<List<City>>(cities => capturedCities = cities); ;
        mockCityServices.Setup(service => service.GetCityByIdAsync(cityId)).ReturnsAsync(new List<City> {
        new City
        {
            cityId= cityId,
            CityName="passos",
            StateCode="mg",
            UpdatedAt= new DateTime(),
            clima =
                new Weather
                {
                    Date = new DateTime(),
                    Condition = "n",
                    MinTemperature = 16,
                    MaxTemperature = 27,
                    UVIndice = 12,
                    Condition_desc = "nublado"
                }
        }
        });       

        // Act
        var result = await cityServices.GetCityByIdAsync(cityId);

        // Assert

        Assert.NotNull(capturedCities);
        Assert.Single(capturedCities); 
        Assert.Equal(cityDto.cidade, capturedCities[0].CityName);
        mockCityRepository.Verify(repo => repo.AddAsync(It.IsAny<List<City>>()), Times.Once);
    }

    [Fact]
    public async Task GetCityByIdAsync_MultipleCities_Success()
    {
        // Arrange
        
        var mockCityRepository = new Mock<ICityRepository>();
        var mockLoggerRepository = new Mock<ILoggerRepository>();
        var mockAirportInfoRepository = new Mock<IAirportInfoRepository>();
        var fakeHttpMessageHandler = new FakeHttpMessageHandler();

        // Crie uma instância do HttpClient com o manipulador personalizado
        var httpClient = new HttpClient(fakeHttpMessageHandler);
        var airportDto = new AirportDTO
        {
            CodigoIcao = "ABC123",
            AtualizadoEm = DateTime.Now,
            PressaoAtmosferica = 1013.25F,
            Visibilidade = "10.0",
            Vento = 10,
            DirecaoVento = 360,
            Umidade = 50,
            Condicao = "Ensolarado",
            CondicaoDesc = "Céu limpo",
            Temperatura = 25,
        };

        fakeHttpMessageHandler.Response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(airportDto, new JsonSerializerOptions { WriteIndented = true }))
        };
        fakeHttpMessageHandler.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var cityServices = new CityServices(httpClient, mockAirportInfoRepository.Object, mockCityRepository.Object, mockLoggerRepository.Object);
        var cityIds = 123;
        var cityDtos = new List<CityClimateInfoDTO>
        {
            new CityClimateInfoDTO
    {
        cidade = "Cidade1",
        estado = "Estado1",
        atualizado_em = DateTime.Now,
        Clima = new List<weatherDTO>
        {
            new weatherDTO
            {
                Condicao = "Condicao1",
                Condicao_desc = "Desc1",
                Indice_uv = 1,
                Max = 30,
                Min = 20,
                Data = DateTime.Now
            },
        }
    },
        };
        var fakeResponseMessages = cityDtos.Select(dto => new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(JsonConvert.SerializeObject(dto))
        }).ToList();
        httpClient = new HttpClient(fakeHttpMessageHandler);
        mockCityRepository.Setup(repo => repo.AddAsync(It.IsAny<List<City>>()));

        // Act
        var result = await cityServices.GetCityByIdAsync(cityIds);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cityIds, result[0].Id);
        Assert.Equal(cityDtos.First().cidade, result[0].CityName);
        

        mockCityRepository.Verify(repo => repo.AddAsync(It.IsAny<List<City>>()), Times.Once);
    }
}
