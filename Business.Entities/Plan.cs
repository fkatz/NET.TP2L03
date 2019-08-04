namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        public string Descripcion { get; set; }
        public Especialidad Especialidad { get; set; }

        public override string ToString() {
            return this.Descripcion;
        }
    }
}
