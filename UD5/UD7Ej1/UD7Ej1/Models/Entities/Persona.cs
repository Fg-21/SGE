using System.Runtime.CompilerServices;

namespace UD7Ej1.Models.Entities
{
    public class Persona
    {
        #region atributos
        private int _id;
        private string _nombre;
        private int _edad;
        #endregion



        #region gettersSetters
        public int id {
            get {
                return _id;
            }
        }
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public int edad
        {
            get
            {
                return _edad;
            }
            set
            {
                _edad = value;
            }
        }

        #endregion

        #region constructor
        public Persona(){
            _id = 0;
            _nombre = "";
            _edad = 0;
        }
        #endregion
    }
}
