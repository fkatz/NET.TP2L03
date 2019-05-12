using System;

namespace Business.Entities
{
    public class Personas : BusinessEntity
    {
        public enum TiposPersonas { }

        public int IDPlan { get; set; }
        public int Legajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public TiposPersonas TipoPersona { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

}
