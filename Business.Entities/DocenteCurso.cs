namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        public enum TiposCargos { }

        public TiposCargos TipoCargo { get; set; }
        public Curso Curso { get; set; }
        public Persona Docente { get; set; }
    }
}
