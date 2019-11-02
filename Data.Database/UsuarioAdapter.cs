using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            using (var context = new AcademiaContext())
            {
                return context.Usuario.Include("Persona").ToList();
            }
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                return context.Usuario.Include("Persona").Where(i => i.ID == ID).First();
            }
        }


        public Business.Entities.Usuario FindByUsername(string username)
        {
            using (var context = new AcademiaContext())
            {
                Usuario usr = context.Usuario.Include("Persona")
                .FirstOrDefault(usuario => usuario.NombreUsuario == username);
                return usr;
            }

        }

        protected bool isRepeated(Usuario usuario)
        {
            using (var context = new AcademiaContext())
            {
                return context.Usuario.Count(a => a.ID != usuario.ID && a.Persona.ID == usuario.Persona.ID) > 0;
            }
        }

        public void Delete(int ID)
        {
            using (var context = new AcademiaContext())
            {
                context.Usuario.Remove(context.Usuario.Find(ID));
                context.SaveChanges();
            }
        }

        protected void Update(Usuario usuario)
        {
            using (var context = new AcademiaContext())
            {
                if (isRepeated(usuario)) throw new Exception("Repeated entity");
                var result = context.Usuario.Find(usuario.ID);
                if (result != null)
                {
                    result.Persona = context.Persona.Attach(usuario.Persona);
                    result.Email = usuario.Email;
                    result.Habilitado = usuario.Habilitado;
                    result.NombreUsuario = usuario.NombreUsuario;
                    result.Clave = usuario.Clave;
                    result.State = usuario.State;
                    context.SaveChanges();
                }
            }
        }
        protected void Insert(Usuario usuario)
        {
            using (var context = new AcademiaContext())
            {
                if (isRepeated(usuario)) throw new Exception("Repeated entity");
                var persona = context.Persona.Attach(usuario.Persona);
                usuario.Persona = persona;
                context.Usuario.Add(usuario);
                context.SaveChanges();
            }
        }
        public Usuario FindByPersona(Persona persona)
        {
            using (var context = new AcademiaContext())
            {
                return context.Usuario.Include("Persona").Where(i => i.Persona.ID == persona.ID).FirstOrDefault();
            }
        }
        public void Save(Usuario usuario)
        {
            switch (usuario.State)
            {
                case BusinessEntity.States.Deleted:
                    Delete(usuario.ID);
                    break;
                case BusinessEntity.States.New:
                    Insert(usuario);
                    break;
                case BusinessEntity.States.Modified:
                    Update(usuario);
                    break;
                default:
                    usuario.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
    }
}
