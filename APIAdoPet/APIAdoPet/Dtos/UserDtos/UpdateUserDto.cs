using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Dtos.UserDtos
{
    public class UpdateUserDto
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

        public string? Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

    }
}
