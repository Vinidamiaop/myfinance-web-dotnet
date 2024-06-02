using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _context;
        public PlanoContaService(MyFinanceDbContext context)
        {
            _context = context;
        }
        public void Cadastrar(PlanoConta Entidade)
        {
            var dbSet = _context.PlanoConta;
            if(Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else
            {
                dbSet.Attach(Entidade);
                _context.Entry(Entidade).State = EntityState.Modified;
            }
            _context.SaveChanges();            
        }

        public void Excluir(int Id)
        {
            var planoConta = new PlanoConta() { Id = Id };
            _context.PlanoConta.Remove(planoConta);
            _context.SaveChanges();
        }

        public List<PlanoConta> ListarRegistros()
        {
            return _context.PlanoConta.ToList();
        }

        public PlanoConta RetornarRegistro(int Id)
        {
            return _context.PlanoConta.First(x => x.Id == Id);
        }
    }
}