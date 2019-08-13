using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            using (var context = new AcademiaContext())
            {
                return context.DocenteCurso.Include("Docente").Include("Curso").ToList();
            }
        }

        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.DocenteCurso.Include("Docente").Include("Curso").Where(i=>i.ID==ID).First();
            }
        }

        public List<DocenteCurso> ListByCurso(Curso curso)
        {
            using (var context = new AcademiaContext())
            {
                return context.DocenteCurso.Where(d => d.Curso.ID == curso.ID).Include("Docente").Include("Curso").ToList();
            }
        }

        public List<DocenteCurso> ListByDocente(Persona docente)
        {
            using (var context = new AcademiaContext())
            {
                return context.DocenteCurso.Where(d => d.Docente.ID == docente.ID).Include("Curso").Include("Docente").ToList();
            }
        }

        public void Delete(int ID)
        {
            using (var context = new AcademiaContext())
            {
                context.DocenteCurso.Remove(context.DocenteCurso.Find(ID));
                context.SaveChanges();
            }
        }

        protected void Update(DocenteCurso entity)
        {
            using (var context = new AcademiaContext())
            {
                entity = context.DocenteCurso.Attach(entity);
                entity.Docente = context.Persona.Attach(entity.Docente);
                entity.Curso = context.Curso.Attach(entity.Curso);
                var entry = context.Entry(entity); // Gets the entry for entity inside context
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        protected void Insert(DocenteCurso entity)
        {
            using (var context = new AcademiaContext())
            {
                var Docente = context.Persona.Attach(entity.Docente);
                entity.Docente = Docente;
                var Curso = context.Curso.Attach(entity.Curso);
                entity.Curso = Curso;
                context.DocenteCurso.Add(entity);
                context.SaveChanges();
            }
        }

        public void Save(DocenteCurso entity)
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
