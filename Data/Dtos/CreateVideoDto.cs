using System.ComponentModel.DataAnnotations;

namespace AluraFlixAPI.Data.Dtos
{
    public class CreateVideoDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
    }
}
