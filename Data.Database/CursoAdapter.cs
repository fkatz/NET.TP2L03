using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            using (var context = new AcademiaContext())
            {
                return context.Curso.Include("Comision").Include("Materia").ToList();
            }
        }
        public List<Curso> ListByAño(int año)
        {
            using (var context = new AcademiaContext())
            {
                return context.Curso.Where(c => c.AñoCalendario == año).Include("Comision").Include("Materia").ToList();
            }
        }

        public Business.Entities.Curso GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.Curso.Include("Comision").Include("Materia").Where(i=>i.ID==ID).First();
            }
        }

        public int CantInscriptos(Curso curso)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Count(a => a.Curso.ID == curso.ID);
            }
        }

        public bool AlumnoIsInCurso(Persona alumno, Curso curso)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Count(a => a.Curso.ID == curso.ID && a.Alumno.ID == alumno.ID) == 1;
            }
        }

        public void Delete(int ID)
        {
            using (var context = new AcademiaContext())
            {
                context.Curso.Remove(context.Curso.Find(ID));
                context.SaveChanges();
            }
        }

        protected void Update(Curso entity)
        {
            using (var context = new AcademiaContext())
            {
                entity = context.Curso.Attach(entity);
                entity.Comision = context.Comision.Attach(entity.Comision);
                entity.Materia.Plan = entity.Comision.Plan;
                entity.Materia = context.Materia.Attach(entity.Materia);
                var entry = context.Entry(entity); // Gets the entry for entity inside context
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        protected void Insert(Curso entity)
        {
            using (var context = new AcademiaContext())
            {
                entity.Comision = context.Comision.Attach(entity.Comision);
                entity.Materia.Plan = entity.Comision.Plan;
                entity.Materia = context.Materia.Attach(entity.Materia);
                context.Curso.Add(entity);
                context.SaveChanges();
            }
        }

        public void Save(Curso entity)
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
