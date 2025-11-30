using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;

namespace Domain.Dtos
{
    public class PersonaWithNombreDepartamentoDto
    {
        #region Fields
        private Persona _persona;
        private string _nombreDepartamento;
        #endregion

        #region Properties
        public Persona persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        public string nombreDepartamento
        {
            get { return _nombreDepartamento; }
            set { _nombreDepartamento = value; }
        }
        #endregion

        #region Constructors
        public PersonaWithNombreDepartamentoDto() { }

        public PersonaWithNombreDepartamentoDto(Persona persona, string nombreDepartamento)
        {
            _persona = persona;
            _nombreDepartamento = nombreDepartamento;
        }
        #endregion
    }
}
