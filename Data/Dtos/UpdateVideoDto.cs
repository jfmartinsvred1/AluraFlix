using System.ComponentModel.DataAnnotations;

namespace AluraFlixAPI.Data.Dtos
{
    public class UpdateVideoDto
    {
        [Required]
        [MinLength(2)]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
    }
}
