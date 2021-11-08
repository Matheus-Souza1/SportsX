using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsXs.Domain.Entities;

namespace SportsXs.Infra.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("Name");
            builder.Property(c => c.CorporateName).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("CorporateName");
            builder.Property(c => c.Document).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("Document").IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("Email").IsRequired();
            builder.Property(c => c.Cep).HasMaxLength(40).HasColumnType("varchar(40)").HasColumnName("Cep").IsRequired();
            builder.Property(c => c.TypeClient).HasMaxLength(30).HasColumnType("varchar(30)").HasColumnName("TypeClient").HasConversion<string>().IsRequired();
            builder.Property(c => c.Classification).HasMaxLength(50).HasColumnType("varchar(30)").HasColumnName("Classification").HasConversion<string>().IsRequired();

            builder.HasMany(c => c.Phones)
                .WithOne()
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
