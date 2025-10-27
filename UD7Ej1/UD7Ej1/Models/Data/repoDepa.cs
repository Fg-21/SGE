using UD7Ej1.Models.Entities;

namespace UD7Ej1.Models.Data
{
    public class repoDepa
    {
        public static List<clsDepartamento> getDepartamentos()
        {
            return new List<clsDepartamento>
            {
                new clsDepartamento(id: 0, nombre: "Marketing"),
                new clsDepartamento(id: 1, nombre: "Recursos Humanos"),
                new clsDepartamento(id: 2, nombre: "Finanzas"),
                new clsDepartamento(id: 3, nombre: "Tecnología"),
                new clsDepartamento(id: 4, nombre: "Ventas")
            };
        }
    }
}
