using Microsoft.EntityFrameworkCore;
using Nbp_currency.Models;

namespace Nbp_currency.Repository

{
    public class NbpContext : DbContext
    {
        public NbpContext()
        {

        }

        public NbpContext(DbContextOptions<NbpContext> options) : base(options)
        {

        }

        public virtual DbSet<LogRecord> LogRecord { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=nbp_currency", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<LogRecord>(entity =>
            {


                entity.ToTable("nbp_currency");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id).IsRequired();

                entity.Property(e => e.CurrencyCode).HasColumnName("currency_code");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.RequestTime).HasColumnName("request_time");

                entity.HasAlternateKey(e => e.Id);
            });
        }
            
    }
}
