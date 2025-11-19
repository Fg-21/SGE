using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class  Persona
    {
        #region atributos privados
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _direccion;
        private string _foto;
        private DateTime _fecha;
        #endregion

        #region getters y setters
        public int id { 
            get { return _id; }
            set { _id = value; }
        }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        #endregion

        #region constructores
        public Persona() { }

        public Persona(int id, string nombre, string apellido, string telefono, string direccion, string foto, DateTime fecha)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _telefono = telefono;
            _direccion = direccion;
            _foto = foto;
            _fecha = fecha;
        }
        #endregion

    }
}
