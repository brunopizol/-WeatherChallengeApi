using developChallenge.Domain.Entities;
using developChallenge.Infra.Context;
using developChallenge.Infra.Repository;
using Microsoft.EntityFrameworkCore;
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
        public async Task AddAsync_SingleCity_ShouldAddToDatabase()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<MyDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryCityDatabase")
                .Options;

            using (var dbContext = new MyDatabaseContext(dbContextOptions))
            {
                var repository = new CityRepository(dbContext, loggerRepository: null);

                // Act
                var city = new City
                {
                    Id = 1,
                    cityId=1,
                    CityName="passos",
                    clima = new Weather
                    {
                        Condition="pn",
                        Condition_desc="nublado",
                        Date=new DateTime(),
                        MaxTemperature= 24,
                        MinTemperature=16,
                        UVIndice=3,
                    },
                    StateCode="MG",
                    UpdatedAt=new DateTime(),

                };
                await repository.AddAsync(new List<City> { city });

                // Assert
                var citiesInDatabase = await dbContext.Cities.ToListAsync();
                Assert.Single(citiesInDatabase); // Ensure there's only one city in the database
                Assert.Equal(city.CityName, citiesInDatabase[0].CityName); // Validate other properties
            }
        }

        [Fact]
        public async Task AddAsync_MultipleCities_ShouldAddToDatabase()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<MyDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryCityDatabase")
                .Options;

            using (var dbContext = new MyDatabaseContext(dbContextOptions))
            {
                var repository = new CityRepository(dbContext, loggerRepository: null);

                // Act
                var cities = new List<City>
                {
                    new City
                    {
                       Id = 1,
                    cityId=1,
                    CityName="passos",
                    clima = new Weather
                    {
                        Condition="pn",
                        Condition_desc="nublado",
                        Date=new DateTime(),
                        MaxTemperature= 24,
                        MinTemperature=16,
                        UVIndice=3,
                    },
                    StateCode="MG",
                    UpdatedAt=new DateTime(),
                    },
                    new City
                    {
                        Id = 2,
                    cityId=2,
                    CityName="varginha",
                    clima = new Weather
                    {
                        Condition="pn",
                        Condition_desc="nublado",
                        Date=new DateTime(),
                        MaxTemperature= 24,
                        MinTemperature=16,
                        UVIndice=3,
                    },
                    StateCode="MG",
                    UpdatedAt=new DateTime(),
                    }
                };

                await repository.AddAsync(cities);

                // Assert
                var citiesInDatabase = await dbContext.Cities.ToListAsync();
                Assert.Equal(2, citiesInDatabase.Count); // Ensure both cities are in the database
                Assert.Equal(cities[0].CityName, citiesInDatabase[0].CityName); // Validate properties
                Assert.Equal(cities[1].CityName, citiesInDatabase[1].CityName); // Validate properties of the second city
            }
        }

    }
}
