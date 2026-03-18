namespace cp4_Projeto.Models
{
    public class Problema
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string TempoResposta { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Icone { get; set; } = "🛠️";
    }
}
