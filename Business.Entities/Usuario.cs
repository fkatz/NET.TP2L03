namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public bool Habilitado { get; set; }
    }
}
