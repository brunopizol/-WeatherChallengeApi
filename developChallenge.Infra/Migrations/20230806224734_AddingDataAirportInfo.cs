using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace developChallenge.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddingDataAirportInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AirportsInfos",
                table: "AirportsInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AirportsInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AirportsInfos",
                table: "AirportsInfos",
                column: "ICAO");

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
            migrationBuilder.DropPrimaryKey(
                name: "PK_AirportsInfos",
                table: "AirportsInfos");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBAR");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBBE");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBBR");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBBV");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBCB");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBCF");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBCG");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBCH");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBCT");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBCX");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBCY");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBCZ");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBDN");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBEG");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBFI");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBFL");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBFN");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBFZ");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBGL");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBGO");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBGR");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBGU");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBIL");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBIZ");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBJP");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBJU");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBJV");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBKG");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBKP");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBLO");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBMA");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBME");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBMG");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBMK");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBMO");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBMQ");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBNF");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBNT");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBPA");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBPL");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBPS");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBPV");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBRB");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBRF");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBRJ");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBSL");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBSN");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBSP");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBSV");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBTE");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBUL");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBVG");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SBVT");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SDPY");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SJTC");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SNEN");

            migrationBuilder.DeleteData(
                table: "AirportsInfos",
                keyColumn: "ICAO",
                keyValue: "SSPS");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AirportsInfos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AirportsInfos",
                table: "AirportsInfos",
                column: "Id");
        }
    }
}
