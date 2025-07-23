namespace CadastroApi.Models
{
    public class Regiao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }  // Exemplo: MG, SP, RJ
        public string Situacao { get; set; } // Exemplo: Ativa, Inativa
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
