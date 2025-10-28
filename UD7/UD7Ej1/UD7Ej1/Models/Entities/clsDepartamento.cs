namespace UD7Ej1.Models.Entities
{
    public class clsDepartamento
    {
        private int _idDepa;
        private string _nombreDepa;

        public clsDepartamento(int id, string nombre) {
        this._idDepa = id;
        this._nombreDepa = nombre;
        }

        public int id
        {
            get
            {
                return this._idDepa;
            }
        }
        
        public string nombre
        {
            get
            {
                return this._nombreDepa;
            }
        }
    }
}
