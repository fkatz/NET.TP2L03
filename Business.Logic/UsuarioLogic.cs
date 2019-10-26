using Business.Entities;
using System.Collections.Generic;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        Data.Database.UsuarioAdapter UsuarioData { get; set; }
        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }
        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }
        public Usuario FindByUsername(string username)
        {
            return UsuarioData.FindByUsername(username);
        }
        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }
        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }
        public Usuario FindByPersona(Persona persona)
        {
            return UsuarioData.FindByPersona(persona);
        }
    }
}
