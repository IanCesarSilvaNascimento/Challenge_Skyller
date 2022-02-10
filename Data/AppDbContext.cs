using DesafioSky.Data.Maps;
using DesafioSky.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioSky.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Inventory>? Inventories { get; set; }

        public DbSet<Purchase>? Purchases { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
                   => options.UseSqlite("DataSource=app.db;Cache=Shared");

        //  DESMARCAR PARA USAR O DOCKER COM O CONTAINER SQLSERVER
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //          => options.UseSqlServer("Server=localhost,1433;Database=Desafiosky;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.ApplyConfiguration(new InventoryMap());
        //     modelBuilder.ApplyConfiguration(new PurchaseMap());


        // }



    }
}