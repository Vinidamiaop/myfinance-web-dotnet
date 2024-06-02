namespace myfinance_web_dotnet_domain.Entities
{
    public class PlanoConta : Entity
    {
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        protected PlanoConta()
        {
            
        }

        public PlanoConta(string descricao, string tipo)
        {
            Descricao = descricao;
            Tipo = tipo;
        }
    }
}