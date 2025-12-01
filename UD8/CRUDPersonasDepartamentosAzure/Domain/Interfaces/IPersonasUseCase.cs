using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Dtos;

namespace Domain.Interfaces
{
    public interface IPersonasUseCase
    {
        #region CRUD Methods
        int createPersona(Persona newPersona);
        Persona getPersonaById(int id);
        Persona[] getListaPersonas();
        int updatePersona(int id, Persona ePersona);
        int deletePersona(int id);
        #endregion

        #region DTO Methods
        PersonaWithNombreDepartamentoDto getPersonaWithNombreDepartamentoById(int idPersona);
        PersonaWithListaDepartamentosDto getPersonaWithListaDepartamentos(int idPersona);
        public PersonaWithListaDepartamentosDto GetPersonaParaCrear();
        #endregion
    }
}

