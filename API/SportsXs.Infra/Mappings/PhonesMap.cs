using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsXs.Domain.Entities;

namespace SportsXs.Infra.Mappings
{
    public class PhonesMap : IEntityTypeConfiguration<Phones>
    {
        public void Configure(EntityTypeBuilder<Phones> builder)
        {
            builder.ToTable("Phones");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Number).HasMaxLength(80).HasColumnType("varchar(80)").HasColumnName("Phones").IsRequired();
        }
    }
}
