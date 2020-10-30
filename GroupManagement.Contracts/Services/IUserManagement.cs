using GroupManagement.Dto.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.Contracts
{
    public interface IUserManagement
    {
        void Add(UserData user);
    }
}
