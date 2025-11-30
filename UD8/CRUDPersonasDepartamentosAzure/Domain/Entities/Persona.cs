using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona
    {
        #region Fields
        private int _id;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _dirección;
        private string _foto;
        private DateTime _fecha;
        private int _idDepartamento;
        #endregion

        #region Properties
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

        public string apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public string direccion
        {
            get { return _dirección; }
            set { _dirección = value; }
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

        public int idDepartamento
        {
            get { return _idDepartamento; }
            set { _idDepartamento = value; }
        }
        #endregion

        #region Constructors
        public Persona() { }

        public Persona(int id, string nombre, string apellidos, string telefono, string foto, DateTime fecha, int idDepartamento)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _telefono = telefono;
            _foto = foto;
            _fecha = fecha;
            _idDepartamento = idDepartamento;
        }
        #endregion
    }
}

