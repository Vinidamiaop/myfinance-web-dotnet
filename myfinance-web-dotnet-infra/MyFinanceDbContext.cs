using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;

namespace myfinance_web_dotnet_infra
{
    public class MyFinanceDbContext : DbContext
    {
        // public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options) : base(options)
        // {

        // }

        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=myfinancepuc;User Id=sa;Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyFinanceDbContext).Assembly);
        }

    }
}