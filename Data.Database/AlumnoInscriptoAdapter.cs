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

        public Business.Entities.AlumnoInscripto GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.AlumnoInscripto.Include("Alumno").Include("Curso").Where(i=>i.ID==ID).First();
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
