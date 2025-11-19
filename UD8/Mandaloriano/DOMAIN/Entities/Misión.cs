using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Entities
{
    public class Misión
    {
        #region Atributos
        private int id;
        private string nombre;
        private string descripcion;
        private double recompensa;
        #endregion

        #region Constructores
        // Constructor sin ID
        public Misión(string nombre, string descripcion, double recompensa)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.recompensa = recompensa;
        }

        // Constructor con ID
        public Misión(int id, string nombre, string descripcion, double recompensa)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.recompensa = recompensa;
        }
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public string Descripcion
        {
            get { return descripcion; }
        }

        public double Recompensa
        {
            get { return recompensa; }
        }
        #endregion
    }

}
