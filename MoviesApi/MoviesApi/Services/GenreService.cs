using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Interfaces;
using MoviesApi.Models;

namespace MoviesApi.Services
{
    public class GenreService : IGenre
    {
        private readonly AppDbContext context;

        public GenreService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<bool>> Delete(int idGenre)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<GenreResponse>>> GetAll()
        {
            var genres = await context.genres.ToListAsync();
            return new OkObjectResult(genres);
        }

        public async Task<ActionResult<GenreResponse>> GetOneById(int idGenre)
        {
            var genreExist = await context.genres.AnyAsync(g => g.Id == idGenre);
            if (!genreExist) return new NotFoundObjectResult($"El genero con el id: {idGenre} no se encuentra");

            var genre = await context.genres.FirstOrDefaultAsync(g => g.Id == idGenre);
            return new OkObjectResult(genre);
        }

        public async Task<int> GetOneByName(string name)
        {
            var genreId = await context.genres.Where(g => g.Name == name).Select(s => s.Id).FirstOrDefaultAsync();

            return genreId;
        }

        public async Task<ActionResult<GenreResponse>> Post(GenreRequest genreRequest)
        {
            if (genreRequest == null) return new BadRequestObjectResult("");

            var genre = genreRequest.toGenre(genreRequest);

            context.Add(genre);
            await context.SaveChangesAsync();

            int getOne = await GetOneByName(genreRequest.Name);

            dynamic genreObjet = await context.genres.FirstOrDefaultAsync(g => g.Id == getOne);

            return new OkObjectResult(genreObjet);
        }

        public async Task<ActionResult<bool>> Update(GenreRequest genreRequest, int idGenre)
        {
            throw new NotImplementedException();
        }
    }
}
