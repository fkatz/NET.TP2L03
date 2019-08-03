namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        public string Clave { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public bool Habilitado { get; set; }
        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
