using ApgCoreAPI.Dtos.Character;
using ApgCoreAPI.Models;
using AutoMapper;
using RabbitMQEventBus.Event;
using RabbitMQEventBus.Producer;

namespace ApgCoreAPI
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Character, AddCharacterDto>();
            CreateMap<PublishEvent, TankMonitorProducerEvent>().ReverseMap();

        }
        
    }
}