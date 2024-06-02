using System.ComponentModel.DataAnnotations;

namespace myfinance_web_dotnet.Models
{
    public class PlanoContaModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Tipo { get; set; }
    }
}