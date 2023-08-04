using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developChallenge.Infra.Context
{
    public class MyDatabaseContext : IdentityDbContext
    {
        #region Constructors
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options) { }
        #endregion

        #region DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FluentApi.CategoryFluent());
            modelBuilder.ApplyConfiguration(new FluentApi.ProductFluent());
        }
        #endregion
    }
}
}
