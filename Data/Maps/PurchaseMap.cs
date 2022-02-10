using DesafioSky.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioSky.Data.Maps
{

    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            // Tabela
            builder.ToTable("Purchase");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Address)
                .IsRequired()
                .HasColumnName("Address")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.ProductId)
            .IsRequired()
            .HasColumnName("ProductId")
            .HasColumnType("INT");

         
            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.SendDate)
                .IsRequired()
                .HasColumnName("SendDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("DATEADD(d,10, CURRENT_TIMESTAMP )");


            builder.Property(x => x.EstimatedDeliveryDate)
                .IsRequired()
                .HasColumnName("EstimatedDeliveryDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("DATEADD(m, 1, CURRENT_TIMESTAMP )");








        }
    }
}
