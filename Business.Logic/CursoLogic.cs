using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        Data.Database.CursoAdapter CursoData { get; set; }
        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }
        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }
        public List<Curso> ListByAño(int año)
        {
            return CursoData.ListByAño(año);
        }
        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }
        public void Save(Curso Curso)
        {
            CursoData.Save(Curso);
        }
        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }

        public int CantInscriptos(Curso curso)
        {
            return CursoData.CantInscriptos(curso);
        }
        public bool AlumnoIsInCurso(Persona alumno, Curso curso)
        {
            return CursoData.AlumnoIsInCurso(alumno, curso);
        }
    }
}
