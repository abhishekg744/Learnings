using _net_core_API.Dtos.Character;
using _net_core_API.Models;
using AutoMapper;

namespace _net_core_API
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Character, AddCharacterDto>();
            
        }
        
    }
}