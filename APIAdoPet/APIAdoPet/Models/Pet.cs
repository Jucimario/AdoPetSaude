using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAdoPet.Models
{    
    public class Pet
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Especie { get; set; }

        [Required]        
        [MaxLength(80)]
        public string? Raca { get; set; }

        [Required]        
        public bool Sexo { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Porte { get; set; }

        [Range(0, 30, ErrorMessage = "A idade deve ser de 0 a 30")]
        public int Idade { get; set; }

        [MaxLength(80)]
        public string? Descricao { get; set; }
                
        public string? Foto { get; set; }

        [MaxLength(80)]
        public string? Cidade { get; set; }
        [MaxLength(10)]
        public string? Estado { get; set; }

        public string? Status { get; set; }
                
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
