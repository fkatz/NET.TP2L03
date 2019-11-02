namespace Business.Entities
{
    public class AlumnoInscriptoDTO : BaseDTO
    {

        public AlumnoInscriptoDTO(AlumnoInscripto alumno) {
            this.ID = alumno.ID;
            this.AlumnoID = alumno.Alumno.ID;
            this.Condicion = alumno.Condicion;
            this.AlumnoLegajo = alumno.Alumno.Legajo;
            this.Nota = alumno.Nota;
            this.CursoID = alumno.Curso.ID;
            this.CursoDescripcion = alumno.Curso.ToString();
            this.AlumnoNombre = alumno.Alumno.NombreCompleto;
        }
        public AlumnoInscripto.Condiciones Condicion { get; set; }
        public int AlumnoID { get; set; }
        public string AlumnoNombre { get; set; }
        public int CursoID { get; set; }
        public string CursoDescripcion { get; set; }
        public int Nota { get; set; }
        public int AlumnoLegajo { get; set; }
    }
}