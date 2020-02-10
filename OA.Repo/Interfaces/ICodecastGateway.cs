using OA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo
{
    public interface ICodecastGateway
    {
        List<Codecast> findAllCodecastsSortedChronologically();
        void delete(Codecast codecast);
        Codecast save(Codecast codecast);
        Codecast findCodecastByTitle(string codecastTitle);
    }
}
