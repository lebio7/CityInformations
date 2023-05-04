using AutoMapper;
using CityInformations.Domain.Entities;
using CityInformations.Shared.DTO;

namespace CityInformations.Application.Helpers.MapperExtensions
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<News, NewsDto>();
            CreateMap<NewsDate, NewsDateDto>();
            CreateMap<TypeDate, TypeDateDto>();
            CreateMap<Descr, DescrDto>();
            CreateMap<Date, DateDto>();
        }
    }
}
