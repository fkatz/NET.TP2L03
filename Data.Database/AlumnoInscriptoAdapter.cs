using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class AlumnoInscriptoAdapter : Adapter
    {
        public List<AlumnoInscripto> GetAll()
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Include("Alumno").Include("Curso").ToList();
            }
        }
        public List<AlumnoInscriptoDTO> GetAllAsDTO()
        {
            using (var context = new AcademiaContext())
            {
                List<AlumnoInscripto> alumnos = context.AlumnoInscripto.Include("Alumno").Include("Curso").ToList();
                List<AlumnoInscriptoDTO> alumnosDTO = new List<AlumnoInscriptoDTO>();
                foreach(AlumnoInscripto alumno in alumnos){
                    int cursoID = alumno.Curso.ID;
                    alumno.Curso = context.Curso.Include("Comision").Include("Materia").Where(i => i.ID == cursoID).First();
                    alumnosDTO.Add(new AlumnoInscriptoDTO(alumno));
                }
                return alumnosDTO;
            }
        }
        public List<AlumnoInscripto> ListByCurso(Curso curso)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Where(a=>a.Curso.ID == curso.ID).Include("Alumno").Include("Curso").ToList();
            }
        }
        public List<AlumnoInscripto> ListByCursoAndCondicion(Curso curso, AlumnoInscripto.Condiciones[] condiciones)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Where(a => a.Curso.ID == curso.ID && condiciones.Any(c=>a.Condicion == c)).Include("Alumno").Include("Curso").ToList();
            }
        }
        public List<AlumnoInscripto> ListByAlumno(Persona alumno)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Where(a => a.Alumno.ID == alumno.ID).Include("Alumno").Include("Curso").ToList();
            }
        }

        public List<AlumnoInscripto> ListByCursoAndNoNota(Curso curso)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Where(a => a.Curso.ID == curso.ID && a.Nota == 0).Include("Alumno").Include("Curso").ToList();
            }
        }

        public Business.Entities.AlumnoInscripto GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Include("Alumno").Include("Curso").Where(i=>i.ID==ID).First();
            }
        }

        protected bool isRepeated(AlumnoInscripto alumno)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Count(a => a.ID != alumno.ID && a.Curso.ID == alumno.Curso.ID && a.Alumno.ID == alumno.Alumno.ID) > 0;
            }
        }

        public void Delete(int ID)
        {
            using (var context = new AcademiaContext())
            {
                context.AlumnoInscripto.Remove(context.AlumnoInscripto.Find(ID));
                context.SaveChanges();
            }
        }

        protected void Update(AlumnoInscripto entity)
        {
            using (var context = new AcademiaContext())
            {
                if (isRepeated(entity)) throw new Exception("Repeated entity");
                entity = context.AlumnoInscripto.Attach(entity);
                entity.Alumno = context.Persona.Attach(entity.Alumno);
                entity.Curso = context.Curso.Attach(entity.Curso);
                var entry = context.Entry(entity); // Gets the entry for entity inside context
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        protected void Insert(AlumnoInscripto entity)
        {
            using (var context = new AcademiaContext())
            {
                if (isRepeated(entity)) throw new Exception("Repeated entity");
                var Alumno = context.Persona.Attach(entity.Alumno);
                entity.Alumno = Alumno;
                var Curso = context.Curso.Attach(entity.Curso);
                entity.Curso = Curso;
                context.AlumnoInscripto.Add(entity);
                context.SaveChanges();
            }
        }

        public void Save(AlumnoInscripto entity)
        {
            switch (entity.State)
            {
                case BusinessEntity.States.Deleted:
                    Delete(entity.ID);
                    break;
                case BusinessEntity.States.New:
                    Insert(entity);
                    break;
                case BusinessEntity.States.Modified:
                    Update(entity);
                    break;
                default:
                    entity.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
    }
}
