using OA.Data;
using System;
using OA.Repo;
using System.Collections.Generic;

namespace OA.Service
{
    public class PresentCodecastUsecase
    {
        public List<PresentableCodecast> presentCodecast(User loggedInUser)
        {
            List<PresentableCodecast> presentableCodecasts = new List<PresentableCodecast>();
            List<Codecast> allCodecasts = Context.codecastGateway.findAllCodecastsSortedChronologically();
            foreach (Codecast codecast in allCodecasts)
            {
                PresentableCodecast cc = new PresentableCodecast();            
                cc.publicationDate = codecast.PublicationDate.ToString();
                cc.title = codecast.Title;             
                cc.isViewable = isLicensedToViewCodecast(loggedInUser, codecast);
                cc.isDownloadable = isLicensedToDownloadCodecast(loggedInUser, codecast);
                presentableCodecasts.Add(cc);
            }
            return presentableCodecasts;
        }

        public bool isLicensedToViewCodecast(User user, Codecast codecast)
        {
            List<License> licenses = Context.licenseGateway.findLicensesForUserAndCodecast(user, codecast);
            License l = licenses.Find(e => e.Type == License.LicenseType.VIEWING);
            if (l != null)
                return true;
            else
                return false;
        }

        public bool isLicensedToDownloadCodecast(User user, Codecast codecast)
        {
            List<License> licenses = Context.licenseGateway.findLicensesForUserAndCodecast(user, codecast);
            License l = licenses.Find(e => e.Type == License.LicenseType.DOWANLOADING);
            if (l != null)
                return true;
            else
                return false;
        }

  
    }
}