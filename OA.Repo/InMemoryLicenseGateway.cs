using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo
{
    public class InMemoryLicenseGateway : GatewayUtilites<License>, ILicenseGateway
    {
        public List<License> findLicensesForUserAndCodecast(User user, Codecast codecast)
        {
            List<License> results = new List<License>();
            License license = getEntities().Find(e => e.User.isSame(user) && e.Codecast.isSame(codecast));
            if (license != null)
            {
                results.Add(license);
            }
            return results;
        }
    }
}
