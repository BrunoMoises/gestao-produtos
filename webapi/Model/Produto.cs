using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Model;

[Table("produto")]
public class Produto
{
    [Key]
    [Required]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do produto é obrigatório!")]
    [Column("titulo")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "A descrição do produto é obrigatório!")]
    [Column("descricao")]
    public string Descricao { get; set; }

    [Column("valor")]
    public float Valor { get; set; }
}