using developChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace developChallenge.Infra.Context
{
    public class MyDatabaseContext : DbContext
    {
        #region Constructors
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //sql server
                //optionsBuilder.UseSqlServer("Server=localhost;Database=brasilAPI;Uid=root;Pwd=testedev12345;");
                string connectionString = "server=localhost;port=3306;database=brasilapi;user=root;password=testedev12345";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }

        }
        #endregion

        #region DbSets
        public DbSet<City> Cities { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<AirportInfo> AirportsInfos { get; set; }
        #endregion

        #region Methods



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
            .HasKey(a => a.Id); 

            modelBuilder.Entity<Airport>(entity =>
            {

                entity.Property(e => e.CodigoIcao)
                      .HasMaxLength(10);
                entity.Property(e => e.Condicao)
                      .HasMaxLength(50);
                entity.Property(e => e.CondicaoDesc)
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<City>(entity =>
            {
                
                entity.HasKey(e => e.Id);        
                entity.Property(e => e.CityName)
                      .HasMaxLength(100);

                entity.Property(e => e.StateCode)
                .HasMaxLength(2);

                entity.HasOne(e => e.Clima)
                      .WithOne(c => c.City)
                      .HasForeignKey<Clima>(c => c.CityId);
            });

           
            modelBuilder.Entity<Clima>(entity =>
            {

                entity.HasKey(e => e.CityId);

                entity.HasOne(e => e.City)
                      .WithOne(c => c.Clima)
                      .HasForeignKey<Clima>(c => c.CityId);
            });
           
            modelBuilder.Entity<AirportInfo>().HasKey(a => a.ICAO);

            modelBuilder.Entity<AirportInfo>().Property(a => a.IATA).IsRequired().HasMaxLength(3);
            modelBuilder.Entity<AirportInfo>().Property(a => a.ICAO).IsRequired().HasMaxLength(4);
            modelBuilder.Entity<AirportInfo>().Property(a => a.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<AirportInfo>().Property(a => a.Description).HasMaxLength(100);
            modelBuilder.Entity<AirportInfo>().Property(a => a.CityName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<AirportInfo>().Property(a => a.StateCode).IsRequired().HasMaxLength(2);


            //add some datas from airports to make easy the requests from user

            modelBuilder.Entity<AirportInfo>().HasData(

          new AirportInfo
          {

              IATA = "BSB",
              ICAO = "SBBR",
              Name = "Aeroporto Internacional de Brasília",
              Description = "Presidente Juscelino Kubitschek",
              CityName = "Brasília",
              StateCode = "DF"
          },
        new AirportInfo
        {

            IATA = "CGH",
            ICAO = "SBSP",
            Name = "Aeroporto Internacional de São Paulo",
            Description = "Congonhas",
            CityName = "São Paulo",
            StateCode = "SP"
        },
        new AirportInfo
        {

            IATA = "GIG",
            ICAO = "SBGL",
            Name = "Aeroporto Internacional do Rio de Janeiro",
            Description = "Galeão-Antônio Carlos Jobim",
            CityName = "Rio de Janeiro",
            StateCode = "RJ"
        },
        new AirportInfo
        {

            IATA = "SSA",
            ICAO = "SBSV",
            Name = "Aeroporto Internacional de Salvador",
            Description = "Deputado Luis Eduardo Magalhães",
            CityName = "Salvador",
            StateCode = "BA"
        },
         new AirportInfo
         {

             IATA = "FLN",
             ICAO = "SBFL",
             Name = "Aeroporto Internacional de Florianópolis",
             Description = "Hercílio Luz",
             CityName = "Florianópolis",
             StateCode = "SC"
         },
        new AirportInfo
        {

            IATA = "POA",
            ICAO = "SBPA",
            Name = "Aeroporto Internacional de Porto Alegre",
            Description = "Salgado Filho",
            CityName = "Porto Alegre",
            StateCode = "RS"
        },
        new AirportInfo
        {

            IATA = "VCP",
            ICAO = "SBKP",
            Name = "Aeroporto Internacional de Viracopos",
            Description = "Campinas",
            CityName = "Campinas",
            StateCode = "SP"
        },
        new AirportInfo
        {

            IATA = "REC",
            ICAO = "SBRF",
            Name = "Aeroporto Internacional do Recife",
            Description = "Guararapes – Gilberto Freyre",
            CityName = "Recife",
            StateCode = "PE"
        },
        new AirportInfo
        {

            IATA = "CWB",
            ICAO = "SBCT",
            Name = "Aeroporto Internacional de Curitiba",
            Description = "Afonso Pena",
            CityName = "Curitiba",
            StateCode = "PR"
        },
        new AirportInfo
        {

            IATA = "BEL",
            ICAO = "SBBE",
            Name = "Aeroporto Internacional de Belém",
            Description = "Val de Cans",
            CityName = "Belém",
            StateCode = "PA"
        },
        new AirportInfo
        {

            IATA = "VIX",
            ICAO = "SBVT",
            Name = "Aeroporto de Vitória",
            Description = "Eurico de Aguiar Salles",
            CityName = "Vitória",
            StateCode = "ES"
        },
        new AirportInfo
        {

            IATA = "SDU",
            ICAO = "SBRJ",
            Name = "Aeroporto Santos Dumont",
            CityName = "Santos Dumont",
            StateCode = "RJ"
        },
        new AirportInfo
        {

            IATA = "CGB",
            ICAO = "SBCY",
            Name = "Aeroporto Internacional de Cuiabá",
            Description = "Marechal Rondon",
            CityName = "Cuiabá",
            StateCode = "MT"
        },
        new AirportInfo
        {
            IATA = "CGR",
            ICAO = "SBCG",
            Name = "Aeroporto Internacional de Campo Grande",
            CityName = "Campo Grande",
            StateCode = "MS"
        },
        new AirportInfo
        {

            IATA = "FOR",
            ICAO = "SBFZ",
            Name = "Aeroporto Internacional de Fortaleza",
            Description = "Pinto Martins",
            CityName = "Fortaleza",
            StateCode = "CE"
        },
        new AirportInfo
        {


            IATA = "MCP",
            ICAO = "SBMQ",
            Name = "Aeroporto Internacional de Macapá",
            CityName = "Macapá",
            StateCode = "AP"
        },
        new AirportInfo
        {

            IATA = "MGF",
            ICAO = "SBMG",
            Name = "Aeroporto Regional de Maringá",
            Description = "Silvio Name Junior",
            CityName = "Maringá",
            StateCode = "PR"
        },
        new AirportInfo
        {

            IATA = "GYN",
            ICAO = "SBGO",
            Name = "Aeroporto de Goiânia",
            Description = "Santa Genoveva",
            CityName = "Goiânia",
            StateCode = "GO"
        },
        new AirportInfo
        {

            IATA = "NVT",
            ICAO = "SBNF",
            Name = "Aeroporto Internacional de Navegantes",
            Description = "Ministro Victor Konder",
            CityName = "Navegantes",
            StateCode = "SC"
        },
        new AirportInfo
        {

            IATA = "MAO",
            ICAO = "SBEG",
            Name = "Aeroporto Internacional de Manaus",
            Description = "Eduardo Gomes",
            CityName = "Manaus",
            StateCode = "AM"
        },
        new AirportInfo
        {

            IATA = "NAT",
            ICAO = "SBNT",
            Name = "Aeroporto Internacional de Natal",
            Description = "Augusto Severo",
            CityName = "Natal",
            StateCode = "RN"
        },
        new AirportInfo
        {

            IATA = "BPS",
            ICAO = "SBPS",
            Name = "Aeroporto Internacional de Porto Seguro",
            CityName = "Porto Seguro",
            StateCode = "BA"
        },
        new AirportInfo
        {

            IATA = "MCZ",
            ICAO = "SBMO",
            Name = "Aeroporto de Maceió",
            Description = "Zumbi dos Palmares",
            CityName = "Maceió",
            StateCode = "AL"
        },
        new AirportInfo
        {

            IATA = "PMW",
            ICAO = "SSPS",
            Name = "Aeroporto de Palmas",
            Description = "Brigadeiro Lysias Rodrigues",
            CityName = "Palmas",
            StateCode = "TO"
        },
        new AirportInfo
        {

            IATA = "SLZ",
            ICAO = "SBSL",
            Name = "Aeroporto Internacional de São Luís",
            Description = "Marechal Cunha Machado",
            CityName = "São Luís",
            StateCode = "MA"
        },
        new AirportInfo
        {

            IATA = "GRU",
            ICAO = "SBGR",
            Name = "Aeroporto Internacional de São Paulo",
            Description = "Guarulhos-Governador André Franco Motoro",
            CityName = "Guarulhos",
            StateCode = "SP"
        },
        new AirportInfo
        {

            IATA = "LDB",
            ICAO = "SBLO",
            Name = "Aeroporto de Londrina",
            Description = "Governador José Richa",
            CityName = "Londrina",
            StateCode = "PR"
        },
        new AirportInfo
        {

            IATA = "PVH",
            ICAO = "SBPV",
            Name = "Aeroporto Internacional de Porto Velho",
            Description = "Governador Jorge Teixeira de Oliveira",
            CityName = "Porto Velho",
            StateCode = "RO"
        },
        new AirportInfo
        {

            IATA = "RBR",
            ICAO = "SBRB",
            Name = "Aeroporto Internacional de Rio Branco",
            Description = "Plácido de Castro",
            CityName = "Rio Branco",
            StateCode = "AC"
        },
        new AirportInfo
        {

            IATA = "JOI",
            ICAO = "SBJV",
            Name = "Aeroporto de Joinville",
            Description = "Lauro Carneiro de Loyola",
            CityName = "Joinville",
            StateCode = "SC"
        },
        new AirportInfo
        {

            IATA = "UDI",
            ICAO = "SBUL",
            Name = "Aeroporto de Uberlândia",
            Description = "Ten. Cel. Av. César Bombonato",
            CityName = "Uberlândia",
            StateCode = "MG"
        },
        new AirportInfo
        {

            IATA = "CXJ",
            ICAO = "SBCX",
            Name = "Aeroporto Regional de Caxias do Sul",
            Description = "Hugo Cantergiani",
            CityName = "Caxias do Sul",
            StateCode = "RS"
        },
        new AirportInfo
        {

            IATA = "IGU",
            ICAO = "SBFI",
            Name = "Aeroporto Internacional de Foz do Iguaçu",
            CityName = "Foz do Iguaçu",
            StateCode = "PR"
        },
        new AirportInfo
        {

            IATA = "THE",
            ICAO = "SBTE",
            Name = "Aeroporto de Teresina",
            Description = "Senador Petrônio Portella",
            CityName = "Teresina",
            StateCode = "PI"
        },
        new AirportInfo
        {

            IATA = "AJU",
            ICAO = "SBAR",
            Name = "Aeroporto Internacional de Aracaju",
            Description = "Santa Maria",
            CityName = "Aracaju",
            StateCode = "SE"
        },
        new AirportInfo
        {

            IATA = "JPA",
            ICAO = "SBJP",
            Name = "Aeroporto Internacional de João Pessoa",
            Description = "Presidente Castro Pinto",
            CityName = "João Pessoa",
            StateCode = "PB"
        },
        new AirportInfo
        {

            IATA = "PNZ",
            ICAO = "SBPL",
            Name = "Aeroporto de Petrolina",
            Description = "Senador Nilo Coelho",
            CityName = "Petrolina",
            StateCode = "PE"
        },
        new AirportInfo
        {

            IATA = "CNF",
            ICAO = "SBCF",
            Name = "Aeroporto Internacional de Minas Gerais",
            Description = "Confins – Tancredo Neves",
            CityName = "Confins",
            StateCode = "MG"
        },
        new AirportInfo
        {

            IATA = "BVB",
            ICAO = "SBBV",
            Name = "Aeroporto Internacional de Boa Vista",
            Description = "Atlas Brasil Cantanhede",
            CityName = "Boa Vista",
            StateCode = "RR"
        },
        new AirportInfo
        {

            IATA = "CPV",
            ICAO = "SBKG",
            Name = "Aeroporto de Campina Grande",
            Description = "Presidente João Suassuna",
            CityName = "Campina Grande",
            StateCode = "PB"
        },
        new AirportInfo
        {

            IATA = "STM",
            ICAO = "SBSN",
            Name = "Aeroporto de Santarém",
            Description = "Maestro Wilson Fonseca",
            CityName = "Santarém",
            StateCode = "PA"
        },
        new AirportInfo
        {

            IATA = "IOS",
            ICAO = "SBIL",
            Name = "Aeroporto de Ilhéus/Bahia-Jorge Amado",
            CityName = "Ilhéus",
            StateCode = "BA"
        },
        new AirportInfo
        {

            IATA = "JDO",
            ICAO = "SBJU",
            Name = "Aeroporto de Juazeiro do Norte",
            Description = "Orlando Bezerra",
            CityName = "Juazeiro do Norte",
            StateCode = "CE"
        },
        new AirportInfo
        {

            IATA = "IMP",
            ICAO = "SBIZ",
            Name = "Aeroporto de Imperatriz",
            Description = "Prefeito Renato Moreira",
            CityName = "Imperatriz",
            StateCode = "MA"
        },
        new AirportInfo
        {
            IATA = "XAP",
            ICAO = "SBCH",
            Name = "Aeroporto de Chapecó",
            Description = "Serafin Enoss Bertaso",
            CityName = "Chapecó",
            StateCode = "SC"
        },
        new AirportInfo
        {

            IATA = "MAB",
            ICAO = "SBMA",
            Name = "Aeroporto de Marabá",
            CityName = "Marabá",
            StateCode = "PA"
        },
        new AirportInfo
        {

            IATA = "CZS",
            ICAO = "SBCZ",
            Name = "Aeroporto Internacional de Cruzeiro do Sul",
            CityName = "Cruzeiro do Sul",
            StateCode = "AC"
        },
        new AirportInfo
        {

            IATA = "PPB",
            ICAO = "SBDN",
            Name = "Aeroporto Estadual de Presidente Prudente",
            CityName = "Presidente Prudente",
            StateCode = "SP"
        },
        new AirportInfo
        {

            IATA = "CFB",
            ICAO = "SBCB",
            Name = "Aeroporto Internacional de Cabo Frio",
            CityName = "Cabo Frio",
            StateCode = "RJ"
        },
        new AirportInfo
        {
            IATA = "FEN",
            ICAO = "SBFN",
            Name = "Aeroporto de Fernando de Noronha",
            CityName = "Fernando de Noronha",
            StateCode = "PE"
        },
        new AirportInfo
        {

            IATA = "JTC",
            ICAO = "SJTC",
            Name = "Aeroporto Estadual de Bauru/Arealva",
            CityName = "Bauru",
            StateCode = "SP"
        },
        new AirportInfo
        {

            IATA = "MOC",
            ICAO = "SBMK",
            Name = "Aeroporto de Montes Claros/Mário Ribeiro",
            CityName = "Montes Claros",
            StateCode = "MG"
        },
         new AirportInfo
         {

             IATA = "MEA",
             ICAO = "SBME",
             Name = "Aeroporto de Macaé",
             CityName = "Macaé",
             StateCode = "RJ"
         },
        new AirportInfo
        {

            IATA = "GPB",
            ICAO = "SBGU",
            Name = "Aeroporto Internacional de Ponta Grossa",
            CityName = "Ponta Grossa",
            StateCode = "PR"
        },
        new AirportInfo
        {

            IATA = "ERM",
            ICAO = "SNEN",
            Name = "Aeroporto de Erechim",
            CityName = "Erechim",
            StateCode = "RS"
        },
        new AirportInfo
        {

            IATA = "PPY",
            ICAO = "SDPY",
            Name = "Aeroporto de Pouso Alegre",
            CityName = "Pouso Alegre",
            StateCode = "MG"
        },
        new AirportInfo
        {

            IATA = "VAG",
            ICAO = "SBVG",
            Name = "Aeroporto de Varginha/Major-Brigadeiro Trompowsky",
            CityName = "Varginha",
            StateCode = "MG"
        }
    );




            base.OnModelCreating(modelBuilder);

        }
        #endregion
    }
}

