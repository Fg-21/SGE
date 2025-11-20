using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repos
{
    public interface IRepoPersonasDepartamentos
    {
        #region CRUDPersonas
        Persona[] getListaPersonas();
        Persona getPersonaById(int id);
        int deletePersona(int id);
        int updatePersona(int id, Persona ePersona);
        int createPersona(Persona newPersona);
        #endregion

        #region CRUDDepartamentos
        Departamento[] getDepartamentos();
        int createDepartamento(Departamento newDepartamento);
        Departamento getDepartamentoById(int id);
        int updateDepartamento(int id, Departamento eDepartamento);
        int deleteDepartamento(int id);
        #endregion
    }
}
