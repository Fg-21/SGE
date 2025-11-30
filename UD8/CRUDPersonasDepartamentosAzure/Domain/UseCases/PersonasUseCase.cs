using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using System.Collections.Generic;

namespace UseCases
{
    public class PersonasUseCase : IPersonasUseCase
    {
        #region Fields
        private readonly IRepoPersonas _repoPersonas;
        private readonly IRepoDepartamentos _repoDepartamentos;
        #endregion

        #region Constructors
        public PersonasUseCase(IRepoPersonas repoPersonas, IRepoDepartamentos repoDepartamentos)
        {
            _repoPersonas = repoPersonas;
            _repoDepartamentos = repoDepartamentos;
        }
        #endregion

        #region CRUD Methods
        public int createPersona(Persona newPersona)
        {
            return _repoPersonas.createPersona(newPersona);
        }

        public Persona getPersonaById(int id)
        {
            return _repoPersonas.getPersonaById(id);
        }

        public Persona[] getListaPersonas()
        {
            return _repoPersonas.getListaPersonas();
        }

        public int updatePersona(int id, Persona ePersona)
        {
            return _repoPersonas.updatePersona(id, ePersona);
        }

        public int deletePersona(int id)
        {
            return _repoPersonas.deletePersona(id);
        }
        #endregion

        #region DTO Methods
        public PersonaWithNombreDepartamentoDto getPersonaWithNombreDepartamentoById(int idPersona)
        {
            Persona persona = _repoPersonas.getPersonaById(idPersona);
            if (persona == null) return null;

            Departamento dpto = _repoDepartamentos.getDepartamentoById(persona.idDepartamento);
            string nombreDpto = dpto != null ? dpto.nombre : string.Empty;

            return new PersonaWithNombreDepartamentoDto(persona, nombreDpto);
        }

        public PersonaWithListaDepartamentosDto getPersonaWithListaDepartamentos(int idPersona)
        {
            Persona persona = _repoPersonas.getPersonaById(idPersona);
            if (persona == null) return null;

            List<Departamento> listaDptos = new List<Departamento>(_repoDepartamentos.getListaDepartamento());
            return new PersonaWithListaDepartamentosDto(persona, listaDptos);
        }
        #endregion
    }
}
