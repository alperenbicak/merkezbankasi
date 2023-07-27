
global using Microsoft.EntityFrameworkCore;
using MerkezBankasıRestApi.Kurlar;
using System.Collections.Generic;
namespace MerkezBankasıRestApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MerkezBankasi;Trusted_Connection=true;TrustServerCertificate=true;");

        }
		public DbSet<EskiKur> EskiKurlar { get; set; }
		public DbSet<OtoKur> OtoKurlar { get; set; }
    }
}

