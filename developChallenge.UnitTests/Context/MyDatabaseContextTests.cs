using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using developChallenge.Infra.Context;
using developChallenge.Domain.Entities;

namespace developChallenge.UnitTests.Context;


public class MyDatabaseContextTests
{
    [Fact]
    public void ModelBuilder_Configuration_IsValid()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MyDatabaseContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        // Act & Assert
        using (var context = new MyDatabaseContext(options))
        {
            Assert.True(context.Database.EnsureCreated());

            // You can add additional assertions here to verify entity configurations.
            // For example, check if entity properties are configured correctly.
            // Example: Assert.True(context.Model.FindEntityType(typeof(Airport)).FindProperty("Id").IsKey());
        }
    }

    [Fact]
    public void OnModelCreating_AddsAirportInfoData()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MyDatabaseContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
            .Options;

        // Act & Assert
        using (var context = new MyDatabaseContext(options))
        {
            context.Database.EnsureCreated();

            var airports = context.AirportsInfos.ToList();

            Assert.NotEmpty(airports);
            // Add more assertions to check if the expected data is present.
        }
    }
}
