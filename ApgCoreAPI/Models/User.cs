using System.Collections.Generic;

namespace ApgCoreAPI.Models
{
    public class User
    {
        public int id {get; set;}
        public string Username {get; set;}
        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
        List<Character> Characters {get; set;}

    }
}