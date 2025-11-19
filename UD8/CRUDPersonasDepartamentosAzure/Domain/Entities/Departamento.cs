using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Departamento
    {
        #region atributos privados
        private int _id;
        private string _nombre;
        #endregion

        #region getters y setters
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region constructores
        public Departamento() { }

        public Departamento(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
        #endregion

    }
}
