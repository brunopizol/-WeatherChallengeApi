
namespace developChallenge.UnitTests.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using developChallenge.Domain.Entities;
using developChallenge.Infra.Context;
using developChallenge.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class AirportInfoRepositoryTests
{
    [Fact]
    public void GetByNameAsync_ReturnsMatchingAirportInfos()
    {
        // Arrange
        var dbContext = new Mock<MyDatabaseContext>();
        var airportInfoRepository = new AirportInfoRepository(dbContext.Object);

        var nameToSearch = "Airport";

        var airportInfos = new List<AirportInfo>
        {
            new AirportInfo { Name = "Airport1" },
            new AirportInfo { Name = "Airport2" },
            new AirportInfo { Name = "Another" },
        };

        // Configure a mock DbSet to return the test data
        var mockSet = new Mock<DbSet<AirportInfo>>();
        mockSet.As<IQueryable<AirportInfo>>().Setup(m => m.Provider).Returns(airportInfos.AsQueryable().Provider);
        mockSet.As<IQueryable<AirportInfo>>().Setup(m => m.Expression).Returns(airportInfos.AsQueryable().Expression);
        mockSet.As<IQueryable<AirportInfo>>().Setup(m => m.ElementType).Returns(airportInfos.AsQueryable().ElementType);
        mockSet.As<IQueryable<AirportInfo>>().Setup(m => m.GetEnumerator()).Returns(airportInfos.GetEnumerator());

        dbContext.Setup(d => d.AirportsInfos).Returns(mockSet.Object);

        // Act
        var result = airportInfoRepository.GetByNameAsync(nameToSearch);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count()); // There are two airport infos with names containing "Airport"
    }

    [Fact]
    public void GetByNameAsync_NoMatchingAirportInfos()
    {
        // Arrange
        var dbContext = new Mock<MyDatabaseContext>();
        var airportInfoRepository = new AirportInfoRepository(dbContext.Object);

        var nameToSearch = "NonExistent";

        var airportInfos = new List<AirportInfo>
        {
            new AirportInfo { Name = "Airport1" },
            new AirportInfo { Name = "Airport2" },
            new AirportInfo { Name = "Another" },
        };

        // Configure a mock DbSet to return the test data
        var mockSet = new Mock<DbSet<AirportInfo>>();
        mockSet.As<IQueryable<AirportInfo>>().Setup(m => m.Provider).Returns(airportInfos.AsQueryable().Provider);
        mockSet.As<IQueryable<AirportInfo>>().Setup(m => m.Expression).Returns(airportInfos.AsQueryable().Expression);
        mockSet.As<IQueryable<AirportInfo>>().Setup(m => m.ElementType).Returns(airportInfos.AsQueryable().ElementType);
        mockSet.As<IQueryable<AirportInfo>>().Setup(m => m.GetEnumerator()).Returns(airportInfos.GetEnumerator());

        dbContext.Setup(d => d.AirportsInfos).Returns(mockSet.Object);

        // Act
        var result = airportInfoRepository.GetByNameAsync(nameToSearch);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result); // No airport infos with the name "NonExistent"
    }
}
