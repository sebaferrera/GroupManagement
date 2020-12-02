using GroupManagement.BlazorUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupManagement.BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        public Task<UserRegistrationResultDTO> Register(RegistrationModel user);
        public Task<bool> Login(LoginModel user);
        public Task Logout();
    }
}
