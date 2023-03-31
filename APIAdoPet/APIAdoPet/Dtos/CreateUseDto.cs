using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Dtos;

public class CreateUseDto
{
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80)]
    public string? Email { get; set; }

    [Required]
    [StringLength(80)]
    public string? Password { get; set; }

    [Required]
    public string? Telefone { get; set; }

    public string? Foto { get; set; }

    public bool Habilitado { get; set; }

    public string? Descrição { get; set; }

    public DateTime DataCriacao { get; set; }
}
