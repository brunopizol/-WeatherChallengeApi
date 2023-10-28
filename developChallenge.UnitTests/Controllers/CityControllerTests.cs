using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using developChallenge.Web.Api.Controllers;
using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Services;

namespace developChallenge.UnitTests.Controllers;


public class CityControllerTests
{
    [Fact]
    public async Task GetCityByIdAsync_ReturnsCities()
    {
        // Arrange
        var cityId = 1;
        var expectedCities = new List<City> { /* Preencha com as cidades esperadas */ };
        var cityServices = new Mock<ICityServices>();
        var logger = new Mock<ILogger<cityController>>();
        cityServices.Setup(s => s.GetCityByIdAsync(cityId)).ReturnsAsync(expectedCities);
        var controller = new cityController(cityServices.Object, logger.Object);

        // Act
        var result = await controller.GetCityByIdAsync(cityId);

        // Assert
        Assert.NotNull(result);
        // Adicione asserções para verificar se as cidades no resultado correspondem às esperadas.
    }

    [Fact]
    public async Task GetCityByNameAsync_ReturnsCities()
    {
        // Arrange
        var cityName = "SomeCity";
        var expectedCities = new List<City> { /* Preencha com as cidades esperadas */ };
        var cityServices = new Mock<ICityServices>();
        var logger = new Mock<ILogger<cityController>>();
        cityServices.Setup(s => s.GetCityByNameAsync(cityName)).ReturnsAsync(expectedCities);
        var controller = new cityController(cityServices.Object, logger.Object);

        // Act
        var result = await controller.GetCityByNameAsync(cityName);

        // Assert
        Assert.NotNull(result);
        // Adicione asserções para verificar se as cidades no resultado correspondem às esperadas.
    }
}

