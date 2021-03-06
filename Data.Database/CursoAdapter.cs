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
        public List<Curso> ListByA�o(int a�o)
        {
            using (var context = new AcademiaContext())
            {
                return context.Curso.Where(c => c.A�oCalendario == a�o).Include("Comision").Include("Materia").ToList();
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

        protected bool isRepeated(Curso curso)
        {
            using (var context = new AcademiaContext())
            {
                return context.Curso.Count(a => a.ID != curso.ID && a.Materia.ID == curso.Materia.ID && a.Comision.ID == curso.Comision.ID && a.A�oCalendario == curso.A�oCalendario) > 0;
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
                if (isRepeated(entity)) throw new Exception("Repeated entity");
                entity.Materia.Plan = null;
                var local = context.Set<Materia>()
                    .Local
                    .FirstOrDefault(f => f.ID == entity.Materia.ID);
                if (local != null)
                {
                    context.Entry(local).State = EntityState.Detached;
                }
                context.Entry(entity.Materia).State = System.Data.Entity.EntityState.Unchanged;
                entity = context.Curso.Attach(entity);
                entity.Comision = context.Comision.Attach(entity.Comision);
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
                if (isRepeated(entity)) throw new Exception("Repeated entity");
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
