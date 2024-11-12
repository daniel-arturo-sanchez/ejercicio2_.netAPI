using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi1.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debes rellenar este campo")]
        [DisplayName("Título")]
        [StringLength(15, ErrorMessage = "El título debe tener entre {2} y {0} caracteres",MinimumLength = 5)]

        public string Title { get; set; }
        [Required]
        [DisplayName("Género")]
        [StringLength(12, ErrorMessage = "El título debe tener entre {2} y {0} caracteres", MinimumLength = 2)]
        public string Genre { get; set; }
    }
}
