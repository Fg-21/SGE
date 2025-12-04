using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepoPersonas
    {
        #region CRUD Methods
        int createPersona(Persona newPersona);
        Persona getPersonaById(int id);
        Persona[] getListaPersonas();
        int updatePersona(int id, Persona ePersona);
        int deletePersona(int id);

        List<Persona> getLISTAPersonas();
        #endregion
    }
}

