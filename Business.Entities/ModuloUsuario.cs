using System;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        [Flags]
        public enum PermisosModulos
        {
            Alta = 0b1,
            Baja = 0b10,
            Modificación = 0b100,
            Consulta = 0b1000
        }
        public Modulo Modulo { get; set; }
        public Usuario Usuario { get; set; }
        public PermisosModulos Permisos  { get; set; }
    }
}
