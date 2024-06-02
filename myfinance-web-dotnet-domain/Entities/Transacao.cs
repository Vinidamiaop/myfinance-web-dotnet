namespace myfinance_web_dotnet_domain.Entities
{
    public class Transacao : Entity
    {
        public string Historico { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int PlanoContaId { get; set; }
        public PlanoConta PlanoConta { get; set; }

        protected Transacao()
        { }

        public Transacao(string historico, DateTime data, decimal valor, int planoContaId)
        {
            Historico = historico;
            Data = data;
            Valor = valor;
            PlanoContaId = planoContaId;
        }
    }
}