using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class RepoPersonasMock100 : IRepoPersonas
    {
        public int createPersona(Persona newPersona)
        {
            throw new NotImplementedException();
        }

        public int deletePersona(int id)
        {
            throw new NotImplementedException();
        }

        public Persona[] getListaPersonas()
        {
            throw new NotImplementedException();
        }

        public List<Persona> getLISTAPersonas()
        {
            throw new NotImplementedException();
        }

        public Persona getPersonaById(int id)
        {
            throw new NotImplementedException();
        }

        public int updatePersona(int id, Persona ePersona)
        {
            throw new NotImplementedException();
        }
    }
}
