# Challenge Weather API 
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
"DefaultConnection": "Server=localhost;Database=brasilapi;Uid=root;Pwd=testedev12345;"
```

O SQLServer deu problema no meu computador e nao pude usar o meu de trabalho devido a compliance, entao usei o mysql porem eu deixei todas as partes de codigo do sql server comentados pra mostrar que eu fiz.

Para acessar console basta acessar o menu saida na parte inferior do visual studio.

![Texto alternativo](https://github.com/brunopizol/developChallengeAEC/blob/master/Readme/console.jpeg)


O endpoint do brasilApi para consulta do clima de cidade está com problemas: https://brasilapi.com.br/api/cptec/v1/cidade/ então eu contornei a situação buscando diretamente num endpoint do INPE e usando o ID pra buscar o clima no brasilAPI.

Os aeroportos como é usado o ICAO pra busca no brasilAPI entao eu fiz um seed no entity framework com os dados dos principais aeroportos, com isso é possivel ubscar o aeroporto pelo nome.

Não foi adicionado testes unitarios por que nao deu tempo mesmo, vide os horarios dos commits. Conto com a compreensão de quem for avaliar.
