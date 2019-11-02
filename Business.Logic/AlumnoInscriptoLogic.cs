using Business.Entities;
using System;
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
        public List<AlumnoInscriptoDTO> GetAllAsDTO()
        {
            return AlumnoInscriptoData.GetAllAsDTO();
        }
        public List<AlumnoInscripto> ListByCurso(Curso curso)
        {
            return AlumnoInscriptoData.ListByCurso(curso);
        }
        public List<AlumnoInscripto> ListByCursoAndCondicion(Curso curso,params AlumnoInscripto.Condiciones[] condiciones)
        {
            return AlumnoInscriptoData.ListByCursoAndCondicion(curso,condiciones);
        }
        public List<AlumnoInscripto> ListByAlumno(Persona alumno)
        {
            return AlumnoInscriptoData.ListByAlumno(alumno);
        }

        public List<AlumnoInscripto> ListByCursoAndNoNota(Curso curso)
        {
            return AlumnoInscriptoData.ListByCursoAndNoNota(curso);
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
