using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;

namespace MoviesApi.Interfaces
{
    public interface IGenre
    {
        public Task<ActionResult<GenreResponse>> Post(GenreRequest genreRequest);
        public Task<ActionResult<bool>> Update(GenreRequest genreRequest, int idGenre);
        public Task<ActionResult<bool>> Delete(int idGenre);
        public Task<ActionResult<List<GenreResponse>>> GetAll();
        public Task<ActionResult<GenreResponse>> GetOneById(int idGenre);
        public Task<int> GetOneByName(string name);
    }
}
