using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _context;
        public TransacaoService(MyFinanceDbContext context)
        {
            _context = context;
        }
        public void Cadastrar(Transacao Entidade)
        {
            var dbSet = _context.Transacao;
            if (Entidade.Id == null)
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
            var Transacao = new Transacao() { Id = Id };
            _context.Transacao.Remove(Transacao);
            _context.SaveChanges();
        }

        public List<Transacao> ListarRegistros()
        {
            return _context.Transacao.ToList();
        }

        public Transacao RetornarRegistro(int Id)
        {
            return _context.Transacao.First(x => x.Id == Id);
        }
    }
}