namespace Business.Entities
{
    public class AlumnoInscripto : BusinessEntity
    {
        public enum Condiciones { Aprobado, Regular, Libre, Cursante }

        public Condiciones Condicion { get; set; }
        public Persona Alumno { get; set; }
        public Curso Curso { get; set; }
        public int Nota { get; set; }
    }
}
