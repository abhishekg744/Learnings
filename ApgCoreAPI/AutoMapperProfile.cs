using ApgCoreAPI.Dtos.Character;
using ApgCoreAPI.Models;
using AutoMapper;

namespace ApgCoreAPI
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