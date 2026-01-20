namespace SignalRChat.Entities
{
    public class clsMensajeUsuario
    {
        private string nombre;
        private string mensaje;

        public clsMensajeUsuario(string nombre, string mensaje) { 
            this.nombre = nombre;
            this.mensaje = mensaje; 
        }

        public string Nombre { get { return nombre; } }
        public string Mensaje { get { return mensaje; } }
    }
}
