using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class GenreRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
