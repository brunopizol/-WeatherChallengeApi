using System;
using System.Threading.Tasks;
using developChallenge.Domain.Entities;
using developChallenge.Domain.Interfaces.Repository;
using developChallenge.Infra.Context;
using developChallenge.Infra.Repository;
using Moq;
using Xunit;
namespace developChallenge.UnitTests.Repository
{
    public class AirportRepositoryTests
    {
        [Fact]
        public async Task AddAsync_Success()
        {
            // Arrange
            var dbContext = new Mock<MyDatabaseContext>();
            var loggerRepository = new Mock<ILoggerRepository>();

            var airportRepository = new AirportRepository(dbContext.Object, loggerRepository.Object);
            var airport = new Airport { /* preencha os campos necessários */ };

            dbContext.Setup(d => d.Airports.Add(airport)).Verifiable();
            dbContext.Setup(d => d.SaveChangesAsync(default)).ReturnsAsync(1); // Supondo que uma entidade foi adicionada com sucesso

            loggerRepository.Setup(l => l.AddLogAsync(It.IsAny<Log>())).ReturnsAsync(true);

            // Act
            var result = await airportRepository.AddAsync(airport);

            // Assert
            Assert.True(result); // A operação deve ser bem-sucedida

            dbContext.Verify(d => d.Airports.Add(airport), Times.Once); // Garanta que a entidade foi adicionada
            dbContext.Verify(d => d.SaveChangesAsync(default), Times.Once); // Garanta que o SaveChangesAsync foi chamado

            loggerRepository.Verify(l => l.AddLogAsync(It.IsAny<Log>()), Times.Once); // Garanta que o log foi adicionado
        }

        [Fact]
        public async Task AddAsync_Failure()
        {
            // Arrange
            var dbContext = new Mock<MyDatabaseContext>();
            var loggerRepository = new Mock<ILoggerRepository>();

            var airportRepository = new AirportRepository(dbContext.Object, loggerRepository.Object);
            var airport = new Airport { /* preencha os campos necessários */ };

            dbContext.Setup(d => d.Airports.Add(airport)).Verifiable();
            dbContext.Setup(d => d.SaveChangesAsync(default)).ReturnsAsync(0); // Supondo que nenhuma entidade foi adicionada

            loggerRepository.Setup(l => l.AddLogAsync(It.IsAny<Log>())).ReturnsAsync(true);

            // Act
            var result = await airportRepository.AddAsync(airport);

            // Assert
            Assert.False(result); // A operação deve falhar

            dbContext.Verify(d => d.Airports.Add(airport), Times.Once); // Garanta que a entidade foi adicionada
            dbContext.Verify(d => d.SaveChangesAsync(default), Times.Once); // Garanta que o SaveChangesAsync foi chamado

            loggerRepository.Verify(l => l.AddLogAsync(It.IsAny<Log>()), Times.Once); // Garanta que o log foi adicionado
        }

        [Fact]
        public async Task AddAsync_Exception()
        {
            // Arrange
            var dbContext = new Mock<MyDatabaseContext>();
            var loggerRepository = new Mock<ILoggerRepository>();

            var airportRepository = new AirportRepository(dbContext.Object, loggerRepository.Object);
            var airport = new Airport { /* preencha os campos necessários */ };

            dbContext.Setup(d => d.Airports.Add(airport)).Verifiable();
            dbContext.Setup(d => d.SaveChangesAsync(default)).ThrowsAsync(new Exception("Erro simulado"));

            loggerRepository.Setup(l => l.AddLogAsync(It.IsAny<Log>())).ReturnsAsync(true);

            // Act & Assert

            await Assert.ThrowsAsync<Exception>(() => airportRepository.AddAsync(airport));

            dbContext.Verify(d => d.Airports.Add(airport), Times.Once); // Garanta que a entidade foi adicionada
            dbContext.Verify(d => d.SaveChangesAsync(default), Times.Once); // Garanta que o SaveChangesAsync foi chamado

            loggerRepository.Verify(l => l.AddLogAsync(It.IsAny<Log>()), Times.Once); // Garanta que o log foi adicionado
        }
    }
}

