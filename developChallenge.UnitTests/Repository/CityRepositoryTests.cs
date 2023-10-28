using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Infra.Context;
using developChallenge.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace developChallenge.UnitTests.Repository
{
    public class CityRepositoryTests
    {

        [Fact]
        public async Task AddAsync_Success()
        {
            // Arrange
            var dbContext = new Mock<MyDatabaseContext>();
            var loggerRepository = new Mock<ILoggerRepository>();

            var cityRepository = new CityRepository(dbContext.Object, loggerRepository.Object);

            var cities = new List<City>
        {
            new City { CityName = "City1" },
            new City { CityName = "City2" }
        };

            dbContext.Setup(d => d.Cities.Add(It.IsAny<City>())).Verifiable();
            dbContext.Setup(d => d.SaveChangesAsync(default)).ReturnsAsync(2); // Assuming 2 entities were added successfully

            loggerRepository.Setup(l => l.AddLogAsync(It.IsAny<Log>())).ReturnsAsync(true);

            // Act
            var result = await cityRepository.AddAsync(cities);

            // Assert
            Assert.True(result); // The operation should be successful

            dbContext.Verify(d => d.Cities.Add(It.IsAny<City>()), Times.Exactly(2)); // Ensure that the entities were added
            dbContext.Verify(d => d.SaveChangesAsync(default), Times.Once); // Ensure that SaveChangesAsync was called

            loggerRepository.Verify(l => l.AddLogAsync(It.IsAny<Log>()), Times.Once); // Ensure that the log was added
        }

        [Fact]
        public async Task AddAsync_Failure()
        {
            // Arrange
            var dbContext = new Mock<MyDatabaseContext>();
            var loggerRepository = new Mock<ILoggerRepository>();

            var cityRepository = new CityRepository(dbContext.Object, loggerRepository.Object);

            var cities = new List<City>
        {
            new City { CityName = "City1" }
        };

            dbContext.Setup(d => d.Cities.Add(It.IsAny<City>())).Verifiable();
            dbContext.Setup(d => d.SaveChangesAsync(default)).ReturnsAsync(0); // Assuming no entities were added

            loggerRepository.Setup(l => l.AddLogAsync(It.IsAny<Log>())).ReturnsAsync(true);

            // Act
            var result = await cityRepository.AddAsync(cities);

            // Assert
            Assert.False(result); // The operation should fail

            dbContext.Verify(d => d.Cities.Add(It.IsAny<City>()), Times.Once); // Ensure that the entity was added
            dbContext.Verify(d => d.SaveChangesAsync(default), Times.Once); // Ensure that SaveChangesAsync was called

            loggerRepository.Verify(l => l.AddLogAsync(It.IsAny<Log>()), Times.Once); // Ensure that the log was added
        }

        [Fact]
        public async Task AddAsync_Exception()
        {
            // Arrange
            var dbContext = new Mock<MyDatabaseContext>();
            var loggerRepository = new Mock<ILoggerRepository>();

            var cityRepository = new CityRepository(dbContext.Object, loggerRepository.Object);

            var cities = new List<City>
        {
            new City {  CityName = "City1" }
        };

            dbContext.Setup(d => d.Cities.Add(It.IsAny<City>())).Verifiable();
            dbContext.Setup(d => d.SaveChangesAsync(default)).ThrowsAsync(new Exception("Simulated error"));

            loggerRepository.Setup(l => l.AddLogAsync(It.IsAny<Log>()))
            .Callback<Log>(log => log.status = "Success")
            .ReturnsAsync(true);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => cityRepository.AddAsync(cities));

            dbContext.Verify(d => d.Cities.Add(It.IsAny<City>()), Times.Once); // Ensure that the entity was added
            dbContext.Verify(d => d.SaveChangesAsync(default), Times.Once); // Ensure that SaveChangesAsync was called

            loggerRepository.Verify(l => l.AddLogAsync(It.IsAny<Log>()), Times.Once); // Ensure that the log was added
        }
    }
}
