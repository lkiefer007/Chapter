namespace ChapterAPI.Models
{
    public class Livro
    {
        //propriedades da classe livro
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int QuantidadePaginas { get; set; }
        public bool Disponível { get; set; }
    }
}
