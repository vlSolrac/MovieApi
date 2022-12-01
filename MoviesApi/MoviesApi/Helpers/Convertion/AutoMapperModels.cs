using AutoMapper;
using MoviesApi.Models;

namespace MoviesApi.Helpers.Convertion
{
    public class AutoMapperModels : Profile
    {
        public AutoMapperModels()
        {
            //recive, return
            CreateMap<Genre, GenreResponse>().ReverseMap();
            CreateMap<Genre, GenreRequest>().ReverseMap();

        }
    }
}
