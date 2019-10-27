using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public class Authenticator
    {   
        private static UsuarioLogic usuarios = new UsuarioLogic();
        public static Usuario Authenticate(){
            Usuario usuario = null;
            if(HttpContext.Current.Session["usuario"] != null) usuario = usuarios.GetOne((int)HttpContext.Current.Session["usuario"]);
            return usuario;
        }
        public static bool Authorize(Usuario usuario, Persona.TipoPersona tipo){
            bool authorized = false;
            if ((usuario.Persona.Tipo & tipo) == tipo) authorized = true;
            return authorized;
        }
    }
}