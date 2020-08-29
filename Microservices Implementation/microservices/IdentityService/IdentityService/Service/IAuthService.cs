using IdentityService.Entities;
using IdentityService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Service
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(Users user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
