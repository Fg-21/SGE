using UD7Ej1.Models.Data;
using UD7Ej1.Models.Entities;

namespace UD7Ej1.Models.ViewModels
{
    public class EditarPersonaVM
    {
        private Persona _persona;
        private List<clsDepartamento> _departamentos;

        public Persona persona
        {
            get { return persona; }
        }
        
        public List<clsDepartamento> departamentos
        {
            get { return departamentos; }
        }

        public EditarPersonaVM(int posicionPersona) {
            _persona = repoPersonas.getPersonas()[posicionPersona];
            _departamentos = repoDepa.getDepartamentos();
        }

        public EditarPersonaVM()
        {
            Random rand = new Random();
            _persona = repoPersonas.getPersonas()[rand.Next(0, repoPersonas.getPersonas().Count)];
            _departamentos = repoDepa.getDepartamentos();
        }
    }
}
