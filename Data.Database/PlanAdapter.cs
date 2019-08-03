using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            using (var context = new AcademiaContext())
            {
                return context.Plan.Include("Especialidad").ToList();
            }
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.Plan.Include("Especialidad").Where(i=>i.ID==ID).First();
            }
        }


        public void Delete(int ID)
        {
            using (var context = new AcademiaContext())
            {
                context.Plan.Remove(context.Plan.Find(ID));
                context.SaveChanges();
            }
        }

        protected void Update(Plan entity)
        {
            using (var context = new AcademiaContext())
            {
                entity = context.Plan.Attach(entity);
                entity.Especialidad = context.Especialidad.Attach(entity.Especialidad);
                var entry = context.Entry(entity); // Gets the entry for entity inside context
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        protected void Insert(Plan entity)
        {
            using (var context = new AcademiaContext())
            {
                var Especialidad = context.Especialidad.Attach(entity.Especialidad);
                entity.Especialidad = Especialidad;
                context.Plan.Add(entity);
                context.SaveChanges();
            }
        }

        public void Save(Plan entity)
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
