namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        public int AñoEspecialidad { get; set; }
        public int IDPlan { get; set; }
        public string Descripcion { get; set; }
    }
}
