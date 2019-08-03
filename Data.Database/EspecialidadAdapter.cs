using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class EspecialidadAdapter
    {
            public List<Especialidad> GetAll()
            {
                using (var context = new AcademiaContext())
                {
                    return context.Especialidad.ToList();
                }
            }

            public Business.Entities.Especialidad GetOne(int ID)
            {
                using (var context = new AcademiaContext())
                {
                    return context.Especialidad.Where(i => i.ID == ID).First();
                }
            }


            public void Delete(int ID)
            {
                using (var context = new AcademiaContext())
                {
                    context.Especialidad.Remove(context.Especialidad.Find(ID));
                    context.SaveChanges();
                }
            }

            protected void Update(Especialidad entity)
            {
                using (var context = new AcademiaContext())
                {
                    entity = context.Especialidad.Attach(entity);
                    var entry = context.Entry(entity); // Gets the entry for entity inside context
                    entry.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            protected void Insert(Especialidad entity)
            {
                using (var context = new AcademiaContext())
                { 
                    context.Especialidad.Add(entity);
                    context.SaveChanges();
                }
            }

            public void Save(Especialidad entity)
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

}
}
