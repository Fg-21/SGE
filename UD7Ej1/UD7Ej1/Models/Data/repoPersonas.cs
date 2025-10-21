using UD7Ej1.Models.Entities;

namespace UD7Ej1.Models.Data
{
    public class repoPersonas
    {
        private List<Persona> listaPersonas;
        public repoPersonas()
        {
            listaPersonas = new List<Persona>{
    new Persona(){ id = 0, nombre="Fran", edad=19 },
    new Persona(){ id = 1, nombre="Ana", edad=25 },
    new Persona(){ id = 2, nombre="Luis", edad=30 },
    new Persona(){ id = 3, nombre="Carlos", edad=22 },
    new Persona(){ id = 4, nombre="Marta", edad=28 },
    new Persona(){ id = 5, nombre="Sofía", edad=33 },
    new Persona(){ id = 6, nombre="Javier", edad=27 },
    new Persona(){ id = 7, nombre="Lucía", edad=24 },
    new Persona(){ id = 8, nombre="Diego", edad=31 },
    new Persona(){ id = 9, nombre="Elena", edad=26 },
    new Persona(){ id = 10, nombre="Pablo", edad=29 },
    new Persona(){ id = 11, nombre="Valeria", edad=23 },
    new Persona(){ id = 12, nombre="Tomás", edad=35 },
    new Persona(){ id = 13, nombre="Clara", edad=21 }
};

        }

        public List<Persona> listado
        {
            get { return listaPersonas; }
        }
    }
}
