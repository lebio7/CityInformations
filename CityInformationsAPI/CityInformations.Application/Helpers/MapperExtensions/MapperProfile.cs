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
        }
    }
}
