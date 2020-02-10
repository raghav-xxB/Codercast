using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo
{
    public interface IUserGateway
    {
        User save(User user);
        User findUserByName(string userName);
    }
}
