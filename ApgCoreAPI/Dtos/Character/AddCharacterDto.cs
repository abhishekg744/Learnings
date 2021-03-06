using ApgCoreAPI.Models;

namespace ApgCoreAPI.Dtos.Character
{
    public class AddCharacterDto
    {
        public string Name {get; set;} = "Alice";
        public int HitPoints {get; set;}
        public int Strength {get; set;}
        public int Defence {get; set;}
        public int Intelligence {get; set;}
        public RpgClass Class {get; set;} = RpgClass.Mage;
    }
    
}