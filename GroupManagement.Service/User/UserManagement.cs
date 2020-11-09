using GroupManagement.Contracts;
using GroupManagement.Models.User;
using System.Collections.Generic;

namespace GroupManagement.Service.User
{
    public class UserManagement : IUserManagement
    {
        public UserManagement()
        {

        }

        public void Add(UserModel user)
        {

        }

        public IEnumerable<UserModel> GetAll()
        {
            var users = new List<UserModel>
            {
                new UserModel{ID = 1, Name="AA"},
                new UserModel{ID = 2, Name="BB"},
                new UserModel{ID = 3, Name="CC"}
            };
            return users;
        }

        public UserModel GetUserById(int id)
        {
            return new UserModel { ID = id, Name="Test" };
        }
    }
}
