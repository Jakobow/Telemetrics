using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Telemetrics.Models
{
    public class TelegramContext : DbContext
    {
        public TelegramContext(DbContextOptions<TelegramContext> options)
            : base(options)
        {
        }

        public DbSet<Telegram> Telegrams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DER90PRHZU\SSQLSERVER;Database=Metrics;Trusted_Connection=true");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telegram>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID")
                   .IsRequired();

                entity.Property(e => e.date).HasColumnName("Date")
                    .HasColumnType("datetime");


                entity.Property(e => e.p1).HasColumnName("p1")
                    .HasColumnType("float");


                entity.Property(e => e.p2).HasColumnName("p2")
                    .HasColumnType("float");


                entity.Property(e => e.p3).HasColumnName("p3")
                    .HasColumnType("float");


                entity.Property(e => e.p4).HasColumnName("p4")
                    .HasColumnType("float");


                entity.Property(e => e.p5).HasColumnName("p5")
                    .HasColumnType("float");
                    

                entity.Property(e => e.t1).HasColumnName("t1")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsRequired();

            });
        }

    }
}
