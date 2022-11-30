using Microsoft.AspNetCore.Mvc;
using MoviesApi.Interfaces;
using MoviesApi.Models;

namespace MoviesApi.Services
{
    public class GenreService : IGenre
    {
        public Task<ActionResult<bool>> Delete(int idGenre)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<GenreResponse>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<GenreResponse>> GetOne(int idGenre)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<bool>> Post(GenreRequest genreRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<bool>> Update(GenreRequest genreRequest, int idGenre)
        {
            throw new NotImplementedException();
        }
    }
}
