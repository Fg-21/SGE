using Domain.Entities;
using Domain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepoVacio : IGetListaPersonas
    {
        public Persona[] getListaPersonas()
        {
            return [];
        }
    }
}
