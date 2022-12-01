using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;

namespace MoviesApi.Interfaces
{
    public interface IGenre
    {
        public Task<ActionResult> Post(GenreRequest genreRequest);
        public Task<ActionResult> Update(GenreRequest genreRequest, int idGenre);
        public Task<ActionResult> Delete(int idGenre);
        public Task<ActionResult> GetAll();
        public Task<ActionResult> GetOneById(int idGenre);
        public Task<int> GetOneByName(string name);
    }
}
