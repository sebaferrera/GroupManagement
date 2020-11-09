using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.Models.User
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public UserModel()
        {
            __Clear();

        }

        private void __Clear()
        {
            this.ID = 0;
            this.Name = "";
        }
    }
}
