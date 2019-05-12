namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        public int IDModulo { get; set; }
        public int IDUsuario { get; set; }
        public bool PermiteAlta { get; set; }
        public bool PermiteBaja { get; set; }
        public bool PermiteModificacion { get; set; }
        public bool PermiteConsulta { get; set; }
    }
}
