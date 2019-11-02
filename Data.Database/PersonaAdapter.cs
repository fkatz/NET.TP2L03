using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            using (var context = new AcademiaContext())
            {
                return context.Persona.ToList();
            }
        }

        public Business.Entities.Persona GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.Persona.Where(i=>i.ID==ID).First();
            }
        }

        public Persona FindByLegajo(int legajo)
        {
            using (var context = new AcademiaContext())
            {
                return context.Persona.Where(i => i.Legajo == legajo).FirstOrDefault();
            }
        }

        public void Delete(int ID)
        {
            using (var context = new AcademiaContext())
            {
                context.Persona.Remove(context.Persona.Find(ID));
                context.SaveChanges();
            }
        }

        protected void Update(Persona entity)
        {
            using (var context = new AcademiaContext())
            {
                entity = context.Persona.Attach(entity);
                var entry = context.Entry(entity); // Gets the entry for entity inside context
                entry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        protected void Insert(Persona entity)
        {
            using (var context = new AcademiaContext())
            {

                context.Persona.Add(entity);
                context.SaveChanges();
            }
        }

        public void Save(Persona entity)
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
