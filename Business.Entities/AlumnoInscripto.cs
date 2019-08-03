namespace Business.Entities
{
    public class AlumnoInscripto : BusinessEntity
    {
        public string Condicion { get; set; }
        public Persona Alumno { get; set; }
        public Curso Curso { get; set; }
        public int Nota { get; set; }
    }
}
