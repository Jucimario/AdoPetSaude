using APIAdoPet.Dtos.PetDtos;
using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Dtos.UserDtos
{
    public class UserDto
    {
        public UserDto()
        {
            Pets = new List<PetDto>();
        }

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(80)]
        public string? Email { get; set; }

        [Required]
        public string? Telefone { get; set; }

        public string? Foto { get; set; }

        public bool Habilitado { get; set; }

        public string? Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public ICollection<PetDto>? Pets { get; set; }
    }
}
