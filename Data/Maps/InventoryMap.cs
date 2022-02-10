using DesafioSky.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioSky.Data.Maps
{

    public class InventoryMap : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            // Tabela
            builder.ToTable("Inventory");

            // Chave Primária
            builder.HasKey(x => x.Id);


            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80);

            builder.Property(x => x.ProductId)
            .IsRequired()
            .HasColumnName("ProductId")
            .HasColumnType("INT");



            builder.Property(x => x.Department)
                .IsRequired()
                .HasColumnName("Department")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.StartingInventory)
                .IsRequired()
                .HasColumnName("StartingInventory")
                .HasColumnType("INT");

            builder.Property(x => x.CurrentInvetory)
                .IsRequired()
                .HasColumnName("CurrentInventory")
                .HasColumnType("INT");

            builder.Property(x => x.InventoryReceived)
                .IsRequired()
                .HasColumnName("InventoryReceived")
                .HasColumnType("INT");

            builder.Property(x => x.InventorySold)
               .IsRequired()
               .HasColumnName("InventorySold")
               .HasColumnType("INT");

            builder.Property(x => x.MinRequired)
                .IsRequired()
                .HasColumnName("MinRequired")
                .HasColumnType("INT");

            builder.Property(x => x.Status)
               .IsRequired()
               .HasColumnName("Status")
               .HasColumnType("INT");

        }
    }
}
