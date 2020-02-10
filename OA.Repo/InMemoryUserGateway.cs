using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo
{
    public class InMemoryUserGateway : GatewayUtilites<User>, IUserGateway
    {
        public User findUserByName(string userName)
        {
            foreach (User user in getEntities())
            {
                if (user.UserName.Equals(userName))
                    return user;
            }
            return null;
        }
    }
}
