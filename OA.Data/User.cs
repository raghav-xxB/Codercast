using System;

namespace OA.Data
{
    public class User : Entity
    {
        private string userName;
       
        public User(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get => userName; set => userName = value; }
     
    }
}