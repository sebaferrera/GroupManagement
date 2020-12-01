using GroupManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroupManagement.Contracts
{
    public interface IUserService
    {
        Task<UserLoggedInDTO> LogIn(UserDTO user);
        Task<UserRegistrationResultDTO> Register(UserDTO userInfo);
    }
}
