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
                return context.Usuario.ToList();
            }
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            using (var context = new AcademiaContext())
            {
                Usuario usr = null;

                return context.Usuario.Find(ID);
            }
        }


        public Business.Entities.Usuario GetByUsername(string username)
        {
            using (var context = new AcademiaContext())
            {
                Usuario usr = context.Usuario
                .FirstOrDefault(usuario => usuario.NombreUsuario == username);
                return usr;
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
                var result = context.Usuario.Find(usuario.ID);
                if (result != null)
                {
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
                context.Usuario.Add(usuario);
                context.SaveChanges();
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
