namespace Business.Entities
{
    public class Comision : BusinessEntity
    {
        public int AñoEspecialidad { get; set; }
        public Plan Plan { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return this.Descripcion;
        }
    }
}
