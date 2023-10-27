using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace developChallenge.Infra.Migrations
{
    /// <inheritdoc />
    public partial class creatingAllTablesAndPopulateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoIcao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PressaoAtmosferica = table.Column<float>(type: "real", nullable: false),
                    Visibilidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vento = table.Column<int>(type: "int", nullable: false),
                    DirecaoVento = table.Column<int>(type: "int", nullable: false),
                    Umidade = table.Column<int>(type: "int", nullable: false),
                    Condicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CondicaoDesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Temperatura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportsInfos",
                columns: table => new
                {
                    ICAO = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    IATA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportsInfos", x => x.ICAO);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StateCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Climas",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinTemperature = table.Column<float>(type: "real", nullable: false),
                    MaxTemperature = table.Column<float>(type: "real", nullable: false),
                    UVIndice = table.Column<float>(type: "real", nullable: false),
                    Condition_desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climas", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Climas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AirportsInfos",
                columns: new[] { "ICAO", "CityName", "Description", "IATA", "Name", "StateCode" },
                values: new object[,]
                {
                    { "SBAR", "Aracaju", "Santa Maria", "AJU", "Aeroporto Internacional de Aracaju", "SE" },
                    { "SBBE", "Belém", "Val de Cans", "BEL", "Aeroporto Internacional de Belém", "PA" },
                    { "SBBR", "Brasília", "Presidente Juscelino Kubitschek", "BSB", "Aeroporto Internacional de Brasília", "DF" },
                    { "SBBV", "Boa Vista", "Atlas Brasil Cantanhede", "BVB", "Aeroporto Internacional de Boa Vista", "RR" },
                    { "SBCB", "Cabo Frio", null, "CFB", "Aeroporto Internacional de Cabo Frio", "RJ" },
                    { "SBCF", "Confins", "Confins – Tancredo Neves", "CNF", "Aeroporto Internacional de Minas Gerais", "MG" },
                    { "SBCG", "Campo Grande", null, "CGR", "Aeroporto Internacional de Campo Grande", "MS" },
                    { "SBCH", "Chapecó", "Serafin Enoss Bertaso", "XAP", "Aeroporto de Chapecó", "SC" },
                    { "SBCT", "Curitiba", "Afonso Pena", "CWB", "Aeroporto Internacional de Curitiba", "PR" },
                    { "SBCX", "Caxias do Sul", "Hugo Cantergiani", "CXJ", "Aeroporto Regional de Caxias do Sul", "RS" },
                    { "SBCY", "Cuiabá", "Marechal Rondon", "CGB", "Aeroporto Internacional de Cuiabá", "MT" },
                    { "SBCZ", "Cruzeiro do Sul", null, "CZS", "Aeroporto Internacional de Cruzeiro do Sul", "AC" },
                    { "SBDN", "Presidente Prudente", null, "PPB", "Aeroporto Estadual de Presidente Prudente", "SP" },
                    { "SBEG", "Manaus", "Eduardo Gomes", "MAO", "Aeroporto Internacional de Manaus", "AM" },
                    { "SBFI", "Foz do Iguaçu", null, "IGU", "Aeroporto Internacional de Foz do Iguaçu", "PR" },
                    { "SBFL", "Florianópolis", "Hercílio Luz", "FLN", "Aeroporto Internacional de Florianópolis", "SC" },
                    { "SBFN", "Fernando de Noronha", null, "FEN", "Aeroporto de Fernando de Noronha", "PE" },
                    { "SBFZ", "Fortaleza", "Pinto Martins", "FOR", "Aeroporto Internacional de Fortaleza", "CE" },
                    { "SBGL", "Rio de Janeiro", "Galeão-Antônio Carlos Jobim", "GIG", "Aeroporto Internacional do Rio de Janeiro", "RJ" },
                    { "SBGO", "Goiânia", "Santa Genoveva", "GYN", "Aeroporto de Goiânia", "GO" },
                    { "SBGR", "Guarulhos", "Guarulhos-Governador André Franco Motoro", "GRU", "Aeroporto Internacional de São Paulo", "SP" },
                    { "SBGU", "Ponta Grossa", null, "GPB", "Aeroporto Internacional de Ponta Grossa", "PR" },
                    { "SBIL", "Ilhéus", null, "IOS", "Aeroporto de Ilhéus/Bahia-Jorge Amado", "BA" },
                    { "SBIZ", "Imperatriz", "Prefeito Renato Moreira", "IMP", "Aeroporto de Imperatriz", "MA" },
                    { "SBJP", "João Pessoa", "Presidente Castro Pinto", "JPA", "Aeroporto Internacional de João Pessoa", "PB" },
                    { "SBJU", "Juazeiro do Norte", "Orlando Bezerra", "JDO", "Aeroporto de Juazeiro do Norte", "CE" },
                    { "SBJV", "Joinville", "Lauro Carneiro de Loyola", "JOI", "Aeroporto de Joinville", "SC" },
                    { "SBKG", "Campina Grande", "Presidente João Suassuna", "CPV", "Aeroporto de Campina Grande", "PB" },
                    { "SBKP", "Campinas", "Campinas", "VCP", "Aeroporto Internacional de Viracopos", "SP" },
                    { "SBLO", "Londrina", "Governador José Richa", "LDB", "Aeroporto de Londrina", "PR" },
                    { "SBMA", "Marabá", null, "MAB", "Aeroporto de Marabá", "PA" },
                    { "SBME", "Macaé", null, "MEA", "Aeroporto de Macaé", "RJ" },
                    { "SBMG", "Maringá", "Silvio Name Junior", "MGF", "Aeroporto Regional de Maringá", "PR" },
                    { "SBMK", "Montes Claros", null, "MOC", "Aeroporto de Montes Claros/Mário Ribeiro", "MG" },
                    { "SBMO", "Maceió", "Zumbi dos Palmares", "MCZ", "Aeroporto de Maceió", "AL" },
                    { "SBMQ", "Macapá", null, "MCP", "Aeroporto Internacional de Macapá", "AP" },
                    { "SBNF", "Navegantes", "Ministro Victor Konder", "NVT", "Aeroporto Internacional de Navegantes", "SC" },
                    { "SBNT", "Natal", "Augusto Severo", "NAT", "Aeroporto Internacional de Natal", "RN" },
                    { "SBPA", "Porto Alegre", "Salgado Filho", "POA", "Aeroporto Internacional de Porto Alegre", "RS" },
                    { "SBPL", "Petrolina", "Senador Nilo Coelho", "PNZ", "Aeroporto de Petrolina", "PE" },
                    { "SBPS", "Porto Seguro", null, "BPS", "Aeroporto Internacional de Porto Seguro", "BA" },
                    { "SBPV", "Porto Velho", "Governador Jorge Teixeira de Oliveira", "PVH", "Aeroporto Internacional de Porto Velho", "RO" },
                    { "SBRB", "Rio Branco", "Plácido de Castro", "RBR", "Aeroporto Internacional de Rio Branco", "AC" },
                    { "SBRF", "Recife", "Guararapes – Gilberto Freyre", "REC", "Aeroporto Internacional do Recife", "PE" },
                    { "SBRJ", "Santos Dumont", null, "SDU", "Aeroporto Santos Dumont", "RJ" },
                    { "SBSL", "São Luís", "Marechal Cunha Machado", "SLZ", "Aeroporto Internacional de São Luís", "MA" },
                    { "SBSN", "Santarém", "Maestro Wilson Fonseca", "STM", "Aeroporto de Santarém", "PA" },
                    { "SBSP", "São Paulo", "Congonhas", "CGH", "Aeroporto Internacional de São Paulo", "SP" },
                    { "SBSV", "Salvador", "Deputado Luis Eduardo Magalhães", "SSA", "Aeroporto Internacional de Salvador", "BA" },
                    { "SBTE", "Teresina", "Senador Petrônio Portella", "THE", "Aeroporto de Teresina", "PI" },
                    { "SBUL", "Uberlândia", "Ten. Cel. Av. César Bombonato", "UDI", "Aeroporto de Uberlândia", "MG" },
                    { "SBVG", "Varginha", null, "VAG", "Aeroporto de Varginha/Major-Brigadeiro Trompowsky", "MG" },
                    { "SBVT", "Vitória", "Eurico de Aguiar Salles", "VIX", "Aeroporto de Vitória", "ES" },
                    { "SDPY", "Pouso Alegre", null, "PPY", "Aeroporto de Pouso Alegre", "MG" },
                    { "SJTC", "Bauru", null, "JTC", "Aeroporto Estadual de Bauru/Arealva", "SP" },
                    { "SNEN", "Erechim", null, "ERM", "Aeroporto de Erechim", "RS" },
                    { "SSPS", "Palmas", "Brigadeiro Lysias Rodrigues", "PMW", "Aeroporto de Palmas", "TO" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "AirportsInfos");

            migrationBuilder.DropTable(
                name: "Climas");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
