# -WeatherChallengeApi
Projeto desenvolvido para vaga na AeC.

Projeto feito em .net 6, com entity framework, mysql e swagger pra documentação dos endpoints.

## Get start

Rode as migrations
```
dotnet ef database update
```

ou 
```
Update-Database
```

configure o AppSettings para o seu ambiente

```
"defaultConnection": "Server=localhost;Database=brasilapi;Trusted_Connection=True; TrustServerCertificate=True;"
```
