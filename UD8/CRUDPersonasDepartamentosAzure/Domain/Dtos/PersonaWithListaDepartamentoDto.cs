using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Dtos
{
    public class PersonaWithListaDepartamentosDto
    {
        #region Fields
        private Persona _persona;
        private List<Departamento> _listaDepartamentos;
        #endregion

        #region Properties
        public Persona persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        public List<Departamento> listaDepartamentos
        {
            get { return _listaDepartamentos; }
            set { _listaDepartamentos = value; }
        }
        #endregion

        #region Constructors
        public PersonaWithListaDepartamentosDto() { }

        public PersonaWithListaDepartamentosDto(Persona persona, List<Departamento> listaDepartamentos)
        {
            _persona = persona;
            _listaDepartamentos = listaDepartamentos;
        }
        #endregion
    }
}

