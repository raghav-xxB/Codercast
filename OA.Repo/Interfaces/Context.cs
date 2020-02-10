using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo
{
    public class Context
    {
        public static IUserGateway userGateway;
        public static ILicenseGateway licenseGateway;
        public static ICodecastGateway codecastGateway;
        public static GateKeeper gateKeeper;
    }
}
