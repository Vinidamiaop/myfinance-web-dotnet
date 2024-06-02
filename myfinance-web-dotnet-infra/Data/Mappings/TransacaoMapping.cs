
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra.Data.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacao");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Historico).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Data).IsRequired();
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.PlanoContaId).IsRequired();
            builder.HasOne(p => p.PlanoConta).WithMany().HasForeignKey(p => p.PlanoContaId);
        }
    }
}