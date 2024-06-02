
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra.Data.Mappings
{
    public class PlanoContaMapping : IEntityTypeConfiguration<PlanoConta>
    {
        public void Configure(EntityTypeBuilder<PlanoConta> builder)
        {
            builder.ToTable("PlanoConta");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Tipo).HasMaxLength(1).IsRequired();
        }
    }
}