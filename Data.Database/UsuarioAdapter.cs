using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta regi�n solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta ser� eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "fkatz";
                    usr.Clave = "fedefede";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", sqlConn);
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario()
                    {
                        ID = (int)drUsuarios["id_usuario"],
                        NombreUsuario = (string)drUsuarios["nombre_usuario"],
                        Clave = (string)drUsuarios["clave"],
                        Habilitado = (bool)drUsuarios["habilitado"],
                        Nombre = (string)drUsuarios["nombre"],
                        Apellido = (string)drUsuarios["apellido"],
                        Email = (string)drUsuarios["email"]
                    };
                    usuarios.Add(usr);
                }
                drUsuarios.Close();
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Exception exManejada = new Exception("Error al recuperar la lista de usuarios", ex);
                throw exManejada;
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario usr = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("select * from usuarios where id_usuario=@id", sqlConn);
                cmdUsuario.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr = new Usuario()
                    {
                        ID = (int)drUsuarios["id_usuario"],
                        NombreUsuario = (string)drUsuarios["nombre_usuario"],
                        Clave = (string)drUsuarios["clave"],
                        Habilitado = (bool)drUsuarios["habilitado"],
                        Nombre = (string)drUsuarios["nombre"],
                        Apellido = (string)drUsuarios["apellido"],
                        Email = (string)drUsuarios["email"]
                    };
                }
                drUsuarios.Close();
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Exception exManejada = new Exception("Error al recuperar el usuario", ex);
                throw exManejada;
            }
            return usr;
        }


        public Business.Entities.Usuario GetByUsername(string username)
        {

            Usuario usr = null;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("select * from usuarios where nombre_usuario=@username", sqlConn);
                cmdUsuario.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = username;
                SqlDataReader drUsuarios = cmdUsuario.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr = new Usuario()
                    {
                        ID = (int)drUsuarios["id_usuario"],
                        NombreUsuario = (string)drUsuarios["nombre_usuario"],
                        Clave = (string)drUsuarios["clave"],
                        Habilitado = (bool)drUsuarios["habilitado"],
                        Nombre = (string)drUsuarios["nombre"],
                        Apellido = (string)drUsuarios["apellido"],
                        Email = (string)drUsuarios["email"]
                    };
                }
                drUsuarios.Close();
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                Exception exManejada = new Exception("Error al recuperar el usuario", ex);
                throw exManejada;
            }
            return usr;
        }


        public bool Delete(int ID)
        {
            bool deleted = false;
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("delete usuarios where id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                deleted = cmdUsuarios.ExecuteNonQuery() == 1;
                this.CloseConnection();
                return deleted;
            }
            catch (Exception ex)
            {
                Exception exManejada = new Exception("Error al eliminar el usuario", ex);
                throw exManejada;
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, " +
                    "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email " +
                    "WHERE id_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                if (cmdSave.ExecuteNonQuery() != 1) throw new Exception("Usuario no encontrado");
            }
            catch (Exception ex)
            {
                Exception exManejada = new Exception("Error al modificar usuario", ex);
                throw exManejada;
            }
        }
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "insert into usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email) " +
                    "values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                usuario.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception exManejada = new Exception("Error al modificar usuario", ex);
                throw exManejada;
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
