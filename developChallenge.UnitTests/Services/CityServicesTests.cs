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

        var mockCityRepository = new Mock<ICityRepository>();
        var mockLoggerRepository = new Mock<ILoggerRepository>();
        var mockAirportInfoRepository = new Mock<IAirportInfoRepository>();
        var fakeHttpMessageHandler = new FakeHttpMessageHandler();

        // Crie uma instância do HttpClient com o manipulador personalizado
        var httpClient = new HttpClient(fakeHttpMessageHandler);
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

        fakeHttpMessageHandler.Response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(cityDto, new JsonSerializerOptions { WriteIndented = true }))
        };
        fakeHttpMessageHandler.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var cityServices = new CityServices(httpClient, mockAirportInfoRepository.Object, mockCityRepository.Object, mockLoggerRepository.Object);
        var cityIds = 123;
        var cityDtos = new List<CityClimateInfoDTO>
        {
            new CityClimateInfoDTO
            {
                cidade = "passos",
                estado = "mg",
                atualizado_em = DateTime.Now,
                Clima = new List<weatherDTO>
                {
                    new weatherDTO
                    {
                        Condicao = "n",
                        Condicao_desc = "nublado",
                        Indice_uv = 12,
                        Max = 27,
                        Min = 16,
                        Data = new DateTime()
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

        Assert.NotNull(cityDtos);
        Assert.Single(cityDtos); 
        Assert.Equal(cityDto.cidade, result[0].CityName);
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

        fakeHttpMessageHandler.Response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(cityDto, new JsonSerializerOptions { WriteIndented = true }))
        };
        fakeHttpMessageHandler.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var cityServices = new CityServices(httpClient, mockAirportInfoRepository.Object, mockCityRepository.Object, mockLoggerRepository.Object);
        var cityIds = 123;
        var cityDtos = new List<CityClimateInfoDTO>
        {
            new CityClimateInfoDTO
            {
                cidade = "passos",
                estado = "mg",
                atualizado_em = DateTime.Now,
                Clima = new List<weatherDTO>
                {
                    new weatherDTO
                    {
                        Condicao = "n",
                        Condicao_desc = "nublado",
                        Indice_uv = 12,
                        Max = 27,
                        Min = 16,
                        Data = new DateTime()
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
        Assert.Equal(cityDtos.First().cidade, result[0].CityName);
        

        mockCityRepository.Verify(repo => repo.AddAsync(It.IsAny<List<City>>()), Times.Once);
    }
}
