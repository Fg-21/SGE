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
        public List<PersonaWithNombreDepartamentoDto> getListaPersonasWithNombreDptos()
        {
            List<PersonaWithNombreDepartamentoDto> lista = new List<PersonaWithNombreDepartamentoDto>();
            List<Persona> listaPersonas;
            listaPersonas = _repoPersonas.getLISTAPersonas();
            string nombreDpto;
            PersonaWithNombreDepartamentoDto dto;

            foreach (Persona persona in listaPersonas)
            {
                nombreDpto = _repoDepartamentos.getDepartamentoById(persona.idDepartamento).nombre;
                dto = new PersonaWithNombreDepartamentoDto(persona, nombreDpto);
                lista.Add(dto);
            }


            return lista;
        }

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

        public PersonaWithListaDepartamentosDto GetPersonaParaCrear()
        {
            Persona personaVacia = new Persona();
            List<Departamento> departamentos = _repoDepartamentos.getListaDepartamento().ToList();

            return new PersonaWithListaDepartamentosDto(personaVacia, departamentos);
        }

        public List<PersonaWithListaDepartamentosDto> getListaPersonasWithListaDepartamentosDto()
        {
            Persona[] listaPersonas = _repoPersonas.getListaPersonas();
            List<PersonaWithListaDepartamentosDto> lista = [];
            List<Departamento> departamentos = _repoDepartamentos.getListaDepartamento().ToList();
            foreach (Persona persona in listaPersonas)
            {
                lista.Add(new PersonaWithListaDepartamentosDto(persona, departamentos));
            }
            return lista;
        }
        #endregion
    }
}
