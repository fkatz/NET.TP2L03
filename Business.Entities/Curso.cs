namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        public int AñoCalendario { get; set; }
        public int Cupo { get; set; }
        public string Descripcion { get; set; }
        public int IDComision { get; set; }
        public int IDMateria { get; set; }
    }
}
