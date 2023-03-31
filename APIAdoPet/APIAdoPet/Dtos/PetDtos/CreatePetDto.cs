using APIAdoPet.Models;
using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Dtos.PetDtos;

public class CreatePetDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(80)]
    public string? Especie { get; set; }

    [Required]
    [StringLength(80)]
    public string? Raca { get; set; }

    [Required]
    public bool Sexo { get; set; }

    [Required]
    [StringLength(80)]
    public string? Porte { get; set; }

    [Range(0, 30, ErrorMessage = "A idade deve ser de 0 a 30")]
    public int Idade { get; set; }

    [StringLength(80)]
    public string? Descricao { get; set; }

    public string? Foto { get; set; }

    [StringLength(80)]
    public string? Cidade { get; set; }
    [StringLength(10)]
    public string? Estado { get; set; }

    public string? Status { get; set; }
        
}
