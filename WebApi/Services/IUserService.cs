using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync (RegisterDto model);
        Task<DataUserDto> GetTokenAync (LoginDto model);
        Task<string> AddRoleAsync (AddRoleDto model);
        Task<DataUserDto> RefreshTokenAsync(string RefreshToken);
    }
}