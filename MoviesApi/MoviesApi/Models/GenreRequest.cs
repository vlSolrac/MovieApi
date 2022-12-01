using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class GenreRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;


        public Genre toGenre(GenreRequest genreRequest)
        {
            Genre geenre = new Genre
            {
                Name = genreRequest.Name,
            };
            return geenre;
        }
    }
}
