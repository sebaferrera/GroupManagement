using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserLoggedInDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool LoggedIn { get; set; }
        public string Token { get; set; }
    }
}
