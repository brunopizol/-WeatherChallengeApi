using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;
using developChallenge.Web.Api.Controllers;
using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Services;

namespace developChallenge.UnitTests.Controllers;


public class AirportControllerTests
{
    [Fact]
    public async Task GetAirportByIdAsync_ReturnsAirport()
    {
        // Arrange
        var airportId = "ABC123";
        var expectedAirport = new Airport { };
        var airportServices = new Mock<IAirportServices>();
        var logger = new Mock<ILogger<AirportController>>();
        airportServices.Setup(s => s.GetAirportByIdAsync(airportId)).ReturnsAsync(expectedAirport);
        var controller = new AirportController(airportServices.Object, logger.Object);

        // Act
        var result = await controller.GetAirportByIdAsync(airportId);

        // Assert
        Assert.NotNull(result);
        
    }

    [Fact]
    public async Task GetAirportByNameAsync_ReturnsAirport()
    {
        // Arrange
        var airportName = "SomeAirport";
        var expectedAirport = new Airport {  };
        var airportServices = new Mock<IAirportServices>();
        var logger = new Mock<ILogger<AirportController>>();
        airportServices.Setup(s => s.GetAirportByNameAsync(airportName)).ReturnsAsync(expectedAirport);
        var controller = new AirportController(airportServices.Object, logger.Object);

        // Act
        var result = await controller.GetAirportByNameAsync(airportName);

        // Assert
        Assert.NotNull(result);
        
    }
}

