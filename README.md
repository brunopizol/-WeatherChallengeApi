# WeatherChallengeApi
Projeto desenvolvido para vaga na AeC.

Projeto feito em .net 6, com entity framework, SQL Server e swagger pra documentação dos endpoints.

## Get start

rodar usando docker
```
docker build -t WeatherChallengeApi .\

docker run -d -p 8080:80 --name WeatherChallengeApi WeatherChallengeApi


```

configure o AppSettings para o seu ambiente

```
"defaultConnection": "Server=localhost;Database=brasilapi;Trusted_Connection=True; TrustServerCertificate=True;"
```

Rode as migrations
```
dotnet ef database update
```

ou 
```
Update-Database
```

endpoints:
```
https://localhost:44361/api/Airport/GetAirportById?id=SBSP
https://localhost:44361/api/Airport/GetAirportByName?name=congonhas
https://localhost:44361/api/city/GetCityById?id=1169
https://localhost:44361/api/city/GetCityByName?name=campestre
```
