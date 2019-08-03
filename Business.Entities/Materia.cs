namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        public int HSSemanales { get; set; }
        public int HSTotales { get; set; }
        public Plan Plan { get; set; }
        public string Descripcion { get; set; }

    }
}
