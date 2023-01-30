namespace Veiculos.Presentation.Models
{
    public class AutenticacaoModel
    {
        public Guid IdVendedor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataHoraAcesso { get; set; }
    }
}