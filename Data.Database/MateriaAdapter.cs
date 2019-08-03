using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            using (var context = new AcademiaContext())
            {
                return context.Materia.Include("Plan").ToList();
            }
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.Materia.Include("Plan").Where(i=>i.ID==ID).First();
            }
        }


        public void Delete(int ID)
        {
            using (var context = new AcademiaContext())
            {
                context.Materia.Remove(context.Materia.Find(ID));
                context.SaveChanges();
            }
        }

        protected void Update(Materia entity)
        {
            using (var context = new AcademiaContext())
            {
                entity = context.Materia.Attach(entity);
                entity.Plan = context.Plan.Attach(entity.Plan);
                var entry = context.Entry(entity); // Gets the entry for entity inside context
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        protected void Insert(Materia entity)
        {
            using (var context = new AcademiaContext())
            {
                var Plan = context.Plan.Attach(entity.Plan);
                entity.Plan = Plan;
                context.Materia.Add(entity);
                context.SaveChanges();
            }
        }

        public void Save(Materia entity)
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
