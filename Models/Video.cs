using System.ComponentModel.DataAnnotations;

namespace AluraFlixAPI.Models
{
    public class Video
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
    }
}
