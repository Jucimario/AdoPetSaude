using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAdoPet.Models;

public class User
{
    public User()
    {
        Pets = new Collection<Pet>();        
    }

    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string? Nome { get; set; }

    [Required]
    [MaxLength(80)]
    public string? Email { get; set; }

    [Required]
    [MaxLength(80)]
    public string? Password { get; set; }

    [Required]    
    public string? Telefone { get; set; }

    public string? Foto { get; set; }
    
    public bool Habilitado { get; set; }

    public string? Descrição { get; set; }

    public DateTime DataCriacao { get; set; }

    public ICollection<Pet>? Pets { get; set; }
}
