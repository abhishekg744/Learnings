using System;
using System.Collections.Generic;

namespace IdentityService.Entities
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
