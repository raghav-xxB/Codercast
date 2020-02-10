
using OA.Data;
using OA.Repo;
using OA.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codercast
{
    public class CodecastPresentation
    {
        private PresentCodecastUsecase usecase = new PresentCodecastUsecase();
        public CodecastPresentation()
        {
            TestSetup.setupContext();
        }
        public bool addUser(string userName)
        {
            Context.userGateway.save(new User(userName));
            return true;
        }
        public bool loginUser(string userName)
        {
            User user = Context.userGateway.findUserByName(userName);
            if(user!=null)
            {
                Context.gateKeeper.LoggedInUser = user;
                return true;
            }
            else
            return false;
        }
        public string presentationUser()
        {
            return Context.gateKeeper.LoggedInUser.UserName;
        }
        public bool clearCodecasts()
        {
            List<Codecast> codecasts = Context.codecastGateway.findAllCodecastsSortedChronologically();
            foreach (Codecast codecast in new List<Codecast>(codecasts))
            {
                Context.codecastGateway.delete(codecast);
            }
            return Context.codecastGateway.findAllCodecastsSortedChronologically().Count == 0;
        }
        public int countOfCodecastPresented()
        {
            List<PresentableCodecast> codecasts = usecase.presentCodecast(Context.gateKeeper.LoggedInUser);
            return codecasts.Count;
        }
        public bool createLicenseForViewing(string userName, string codecastTitle)
        {
            User user = Context.userGateway.findUserByName(userName);
            Codecast codecast = Context.codecastGateway.findCodecastByTitle(codecastTitle);
            License license = new License( License.LicenseType.VIEWING, user, codecast);
            Context.licenseGateway.save(license);
            return usecase.isLicensedToViewCodecast(user, codecast);
        }

        public bool createLicenseForDownloading(string userName, string codecastTitle)
        {
            User user = Context.userGateway.findUserByName(userName);
            Codecast codecast = Context.codecastGateway.findCodecastByTitle(codecastTitle);
            License license = new License(License.LicenseType.DOWANLOADING, user, codecast);
            Context.licenseGateway.save(license);
            return usecase.isLicensedToDownloadCodecast(user, codecast);
        }
    }
}
