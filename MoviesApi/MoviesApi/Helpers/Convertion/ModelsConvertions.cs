using MoviesApi.Models;

namespace MoviesApi.Helpers.Convertion
{
    public static class ModelsConvertions
    {
        public static Genre toGenre(this GenreRequest genreRequest)
        {
            return new Genre
            {
                Name = genreRequest.Name,
            };
        }
    }
}
