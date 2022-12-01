using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Helpers.Convertion;
using MoviesApi.Interfaces;
using MoviesApi.Models;

namespace MoviesApi.Services
{
    public class GenreService : IGenre
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public GenreService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ActionResult<bool>> Delete(int idGenre)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> GetAll()
        {
            var genres = await context.genres.ToListAsync();
            var genresDto = mapper.Map<List<GenreResponse>>(genres);
            return new OkObjectResult(genresDto);
        }

        public async Task<ActionResult> GetOneById(int idGenre)
        {
            var genreExist = await context.genres.AnyAsync(g => g.Id == idGenre);
            if (!genreExist) return new NotFoundObjectResult($"El genero con el id: {idGenre} no se encuentra");

            var genre = await context.genres.FirstOrDefaultAsync(g => g.Id == idGenre);
            var genreDto = mapper.Map<GenreResponse>(genre);

            return new OkObjectResult(genreDto);
        }

        public async Task<int> GetOneByName(string name)
        {
            var genreId = await context.genres.Where(g => g.Name == name).Select(s => s.Id).FirstOrDefaultAsync();

            return genreId;
        }

        public async Task<ActionResult> Post(GenreRequest genreRequest)
        {
            if (genreRequest == null) return new BadRequestObjectResult("");

            //var genre = genreRequest.toGenre();            
            var genre = mapper.Map<Genre>(genreRequest);

            context.Add(genre);
            await context.SaveChangesAsync();

            int getID = await GetOneByName(genreRequest.Name);

            dynamic genreObjet = await context.genres.FirstOrDefaultAsync(g => g.Id == getID);

            var genreDto = mapper.Map<GenreResponse>(genreObjet);

            return new OkObjectResult(genreObjet);
        }

        public async Task<ActionResult> Update(GenreRequest genreRequest, int idGenre)
        {
            dynamic genreDto = await GetOneById(idGenre);

            if (genreDto.Result.StatusCode != 200) return genreDto;

            Genre genreMapper = mapper.Map<Genre>(genreDto);

            genreMapper.Id = idGenre;

            context.Entry(genreMapper).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return new OkObjectResult(true);

        }
    }
}
