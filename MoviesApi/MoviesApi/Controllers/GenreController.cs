using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Interfaces;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenre _genre;

        public GenreController(IGenre genre)
        {
            _genre = genre;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreResponse>>> GetAll()
        {
            dynamic res = await _genre.GetAll();

            if (res.Result.StatusCode != 200)
            {
                return res;
            }

            return res;
        }

        [HttpGet]
        [Route("GetOne")]
        public async Task<ActionResult<GenreResponse>> GetOne(int idGenre)
        {
            dynamic res = await _genre.GetOneById(idGenre);

            if (res.Result.StatusCode != 200)
            {
                return res;
            }

            return res;
        }

        [HttpPost]
        public async Task<ActionResult<GenreResponse>> PostOne(GenreRequest genreRequest)
        {
            dynamic res = await _genre.Post(genreRequest);

            if (res.Result.StatusCode != 200) return res;

            return res;
        }

    }
}
