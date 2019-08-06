using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InicializarDatos();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }

        static private void InicializarDatos()
        {
            UsuarioLogic usuarios = new UsuarioLogic();
            PersonaLogic personas = new PersonaLogic();

            if (usuarios.FindByUsername("fkatz") == null)
            {
                Usuario usr = new Usuario()
                {
                    NombreUsuario = "fkatz",
                    Clave = "fedefede",
                    Email = "fkatz@gmail.com",
                    Habilitado = true,
                    State = BusinessEntity.States.New
                };
                usuarios.Save(usr);
                if (personas.FindByLegajo(44744) == null)
                {
                    personas.Save(new Persona()
                    {
                        Nombre = "Federico",
                        Apellido = "Katzaroff",
                        Legajo = 44744,
                        Tipo = Persona.TipoPersona.Alumno | Persona.TipoPersona.Administrador,
                        Direccion = "Guaraní 3048",
                        Telefono = "4398771",
                        FechaNacimiento = new DateTime(1995, 5, 16),
                        Usuario = usr,
                        State = BusinessEntity.States.New
                    });
                }
            }
        }
    }
}
