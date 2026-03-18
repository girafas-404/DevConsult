using System.ComponentModel.DataAnnotations;

namespace cp4_Projeto.Models
{
    public class Solicitacao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100)]
        public string NomeCliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string EmailCliente { get; set; } = string.Empty;

        public int ProblemaId { get; set; }
        public string ProblemaDescricao { get; set; } = string.Empty;

        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
        public StatusSolicitacao Status { get; set; } = StatusSolicitacao.Pendente;

        public string? Observacao { get; set; }
    }

    public enum StatusSolicitacao
    {
        Pendente,
        Aprovada,
        Reprovada,
        EnviadaWhatsApp
    }
}
