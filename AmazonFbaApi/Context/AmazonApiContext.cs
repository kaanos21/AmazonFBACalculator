using AmazonFbaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmazonFbaApi.Context
{
    public class AmazonApiContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-COQ9ECD\\SQLEXPRESS;Database=AmazonDb;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<UsaToAuProduct> UsaToAuProduct { get; set; }

    }
}
