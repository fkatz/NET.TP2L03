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

        public Business.Entities.Curso GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.Curso.Include("Comision").Include("Materia").Where(i=>i.ID==ID).First();
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
                var Comision = context.Comision.Attach(entity.Comision);
                entity.Comision = Comision;
                var Materia = context.Materia.Attach(entity.Materia);
                entity.Materia = Materia;
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
