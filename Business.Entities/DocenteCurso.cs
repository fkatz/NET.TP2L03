namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        public enum TiposCargos { }

        public TiposCargos TipoCargo { get; set; }
        public int IDCurso { get; set; }
        public int IDDocente { get; set; }
    }
}
