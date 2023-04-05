namespace webapi.Data.Dtos;

public class ReadProdutoDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public float Valor { get; set; }
}