namespace CadastroApi.Models
{
    public class Regiao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }  // Exemplo: MG, SP, RJ
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
