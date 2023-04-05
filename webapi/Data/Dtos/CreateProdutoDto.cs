using System.ComponentModel.DataAnnotations;

namespace webapi.Data.Dtos;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "O título do produto é obrigatório!")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "A descrição do produto é obrigatório!")]
    public string Descricao { get; set; }
    
    public float Valor { get; set; }
}