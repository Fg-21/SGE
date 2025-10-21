using UD7Ej1.Models.Entities;

namespace UD7Ej1.Models.Data
{
    public class repoDepa
    {
        private List<clsDepartamento> listaDepas;

        public repoDepa() {

            listaDepas = new List<clsDepartamento>
            {
                new clsDepartamento(id: 0, nombre: "Marketing"),
                new clsDepartamento(id: 1, nombre: "Recursos Humanos"),
                new clsDepartamento(id: 2, nombre: "Finanzas"),
                new clsDepartamento(id: 3, nombre: "Tecnología"),
                new clsDepartamento(id: 4, nombre: "Ventas")
            };

        }

        public List<clsDepartamento> listado
        {
            get
            {
                return listaDepas;
            }
        }
    }
}
