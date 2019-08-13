using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class AlumnoInscriptoLogic : BusinessLogic
    {
        Data.Database.AlumnoInscriptoAdapter AlumnoInscriptoData { get; set; }
        public AlumnoInscriptoLogic()
        {
            AlumnoInscriptoData = new Data.Database.AlumnoInscriptoAdapter();
        }
        public AlumnoInscripto GetOne(int ID)
        {
            return AlumnoInscriptoData.GetOne(ID);
        }
        public List<AlumnoInscripto> GetAll()
        {
            return AlumnoInscriptoData.GetAll();
        }
        public List<AlumnoInscripto> ListByCurso(Curso curso)
        {
            return AlumnoInscriptoData.ListByCurso(curso);
        }
        public List<AlumnoInscripto> ListByCursoAndCondicion(Curso curso,string condicion1, string condicion2)
        {
            return AlumnoInscriptoData.ListByCursoAndCondicion(curso,condicion1,condicion2);
        }
        public List<AlumnoInscripto> ListByAlumno(Persona alumno)
        {
            return AlumnoInscriptoData.ListByAlumno(alumno);
        }
        public void Save(AlumnoInscripto AlumnoInscripto)
        {
            AlumnoInscriptoData.Save(AlumnoInscripto);
        }
        public void Delete(int ID)
        {
            AlumnoInscriptoData.Delete(ID);
        }
    }
}
