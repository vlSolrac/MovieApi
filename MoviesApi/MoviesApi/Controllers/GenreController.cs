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
        public async Task<IActionResult> GetAll()
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
        public async Task<IActionResult> GetOne([FromQuery] int idGenre)
        {
            dynamic res = await _genre.GetOneById(idGenre);

            if (res.Result.StatusCode != 200)
            {
                return res;
            }

            return res;
        }

        [HttpPost]
        public async Task<IActionResult> PostOne([FromBody] GenreRequest genreRequest)
        {
            dynamic res = await _genre.Post(genreRequest);

            if (res.Result.StatusCode != 200) return res;

            return res;
        }

        [HttpPut]
        public async Task<IActionResult> PutOne([FromBody] GenreRequest genreRequest, [FromQuery] int idGenre)
        {
            dynamic res = await _genre.Update(genreRequest, idGenre);

            if (res.Result.StatusCode != 200) return res;

            return res;
        }

    }
}
