using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo
{
    public class InMemoryCodecastGateway : GatewayUtilites<Codecast>, ICodecastGateway
    {     
        public List<Codecast> findAllCodecastsSortedChronologically()
        {
            List<Codecast> codecasts = new List<Codecast>(getEntities());
            codecasts.Sort((x, y) => x.PublicationDate.CompareTo(y.PublicationDate));
            return codecasts;
        }
        public Codecast findCodecastByTitle(string codecastTitle)
        {
            Codecast result = getEntities().Find(e => e.Title == codecastTitle);
            if (result != null)
                return result;
            return null;
        }
    }
}
