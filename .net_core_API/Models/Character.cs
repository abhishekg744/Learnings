namespace _net_core_API.Models
{

    public class Character
    {
        public int Id {get; set;}
        public string Name {get; set;} = "Alice";
        public int HitPoints {get; set;}
        public int Strength {get; set;}
        public int Defence {get; set;}
        public int Intelligence {get; set;}
        public RpgClass Class {get; set;} = RpgClass.Mage;

        
    }
    
}