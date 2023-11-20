using AutoMapper;
using CityInformations.Application.Helpers.Responses;
using CityInformations.Domain.Entities;
using CityInformations.Shared.DTO;

namespace CityInformations.Application.Helpers.MapperExtensions
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<News, NewsDto>();
            CreateMap<NewsDate, NewsDateDto>();
            CreateMap<TypeDate, TypeDateDto>();
            CreateMap<Descr, DescrDto>();
            CreateMap<Date, DateDto>();
            CreateMap<Location, LocationDto>();
            CreateMap<ObjectLocation, ObjectLocationDto>();
            CreateMap<LocationDate, LocationDateDto>();

            CreateMap<OpenWeatherMapResponse, Weather>()
                .ForMember(dest => dest.Temperature, src => src.MapFrom(x => x.Main != null ? x.Main.Temperature : 0))
                .ForMember(dest => dest.Pressure, src => src.MapFrom(x => x.Main != null ? x.Main.Pressure : 0))
                .ForMember(dest => dest.Icon, src => src.MapFrom(x => x.Weather != null && x.Weather.Length > 0 ? x.Weather.FirstOrDefault().Icon : string.Empty));
        }
    }
}
