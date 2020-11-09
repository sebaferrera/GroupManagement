using GroupManagement.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.Contracts
{
    public interface IUserManagement
    {
        void Add(UserModel user);
        IEnumerable<UserModel> GetAll();
        UserModel GetUserById(int id);
    }
}
