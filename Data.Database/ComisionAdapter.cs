using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            using (var context = new AcademiaContext())
            {
                return context.Comision.Include("Plan").ToList();
            }
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.Comision.Include("Plan").Where(i=>i.ID==ID).First();
            }
        }


        public void Delete(int ID)
        {
            using (var context = new AcademiaContext())
            {
                context.Comision.Remove(context.Comision.Find(ID));
                context.SaveChanges();
            }
        }

        protected void Update(Comision entity)
        {
            using (var context = new AcademiaContext())
            {
                entity = context.Comision.Attach(entity);
                entity.Plan = context.Plan.Attach(entity.Plan);
                var entry = context.Entry(entity); // Gets the entry for entity inside context
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        protected void Insert(Comision entity)
        {
            using (var context = new AcademiaContext())
            {
                var Plan = context.Plan.Attach(entity.Plan);
                entity.Plan = Plan;
                context.Comision.Add(entity);
                context.SaveChanges();
            }
        }

        public void Save(Comision entity)
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
