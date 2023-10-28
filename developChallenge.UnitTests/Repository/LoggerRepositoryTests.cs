namespace developChallenge.UnitTests.Repository;
using System;
using System.Net;
using System.Threading.Tasks;
using developChallenge.Domain.Entities;
using developChallenge.Infra.Context;
using developChallenge.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class LoggerRepositoryTests
{
    [Fact]
    public async Task AddLogAsync_Success()
    {
        // Arrange
        var dbContext = new Mock<MyDatabaseContext>();
        var loggerRepository = new LoggerRepository(dbContext.Object);

        var log = new Log { 
        
            Action="sucess",
            CreatedAt = DateTime.UtcNow,
            Description="dados inseridos",
            status = HttpStatusCode.OK.ToString(),
        };
        dbContext.Setup(d => d.Logs.Add(log)).Verifiable();
        dbContext.Setup(d => d.SaveChangesAsync(default)).ReturnsAsync(1); // Assuming 1 log record was added successfully

        // Act
        var result = await loggerRepository.AddLogAsync(log);

        // Assert
        Assert.True(result); // Log record was added successfully

        dbContext.Verify(d => d.Logs.Add(log), Times.Once); // Garanta que o log foi adicionado
        dbContext.Verify(d => d.SaveChangesAsync(default), Times.Once); // Garanta que o SaveChangesAsync foi chamado
    }

    [Fact]
    public async Task AddLogAsync_Exception()
    {
        // Arrange
        var dbContext = new Mock<MyDatabaseContext>();
        var loggerRepository = new LoggerRepository(dbContext.Object);

        
        var log = new Log
        {

            Action = "Error",
            CreatedAt = DateTime.UtcNow,
            Description = "erro no banco de dados",
            status = HttpStatusCode.InternalServerError.ToString(),
        };
        dbContext.Setup(d => d.Logs.Add(log)).Verifiable();
        dbContext.Setup(d => d.SaveChangesAsync(default)).ThrowsAsync(new Exception("Erro simulado"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => loggerRepository.AddLogAsync(log));

        dbContext.Verify(d => d.Logs.Add(log), Times.Once); // Garanta que o log foi adicionado
        dbContext.Verify(d => d.SaveChangesAsync(default), Times.Once); // Garanta que o SaveChangesAsync foi chamado
    }
}

