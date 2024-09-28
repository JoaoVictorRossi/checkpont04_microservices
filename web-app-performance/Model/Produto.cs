namespace web_app_performance.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal preco { get; set; }
        public int quantidade_estoque { get; set; }
        public DateTime data_criacao { get; set; }
    }
}
