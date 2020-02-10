
using OA.Data;
using OA.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public class TestSetup
    {
        public static void setupContext()
        {
            Context.userGateway = new InMemoryUserGateway();
            Context.licenseGateway = new InMemoryLicenseGateway();
            Context.codecastGateway = new InMemoryCodecastGateway();
            Context.gateKeeper = new GateKeeper();
        }

        public static void setupSampleData()
        {
            setupContext();
            User bob = new User("Bob");
            User mike = new User("Mike");
            Context.userGateway.save(bob);
            Context.userGateway.save(mike);

            Codecast c1 = new Codecast();
            c1.Title = "Episode 1: The Begining";
            c1.PublicationDate = DateTime.Now.Date;

            Codecast c2 = new Codecast();
            c2.Title = "Episode 2: The Continuation";
            c2.PublicationDate = DateTime.Now.Date.AddDays(1);
            Context.codecastGateway.save(c1);
            Context.codecastGateway.save(c2);

            License bobE1 = new License(License.LicenseType.VIEWING, bob, c1);
            License bobE2 = new License(License.LicenseType.VIEWING, bob, c2);
            Context.licenseGateway.save(bobE1);
            Context.licenseGateway.save(bobE2);

        }
    }
}
