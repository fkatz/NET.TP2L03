namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        public int AñoCalendario { get; set; }
        public int Cupo { get; set; }
        public Comision Comision { get; set; }
        public Materia Materia { get; set; }
    }
}
