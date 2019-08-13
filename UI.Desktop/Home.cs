using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Home : Form
    {
        private Persona loggedPersona;
        private Usuario loggedUser;
        public Home()
        {
            InitializeComponent();
        }

        public void ActualizarVista()
        {
            if (loggedUser == null)
            {
                this.tsmAdministrar.Visible = false;
                this.tsmAlumno.Visible = false;
                this.tsmDocente.Visible = false;
                this.tsmPreceptor.Visible = false;
                this.tsmCerrarSesion.Visible = false;
                this.tsmIniciarSesion.Visible = true;
            }
            else
            {
                this.tsmCerrarSesion.Visible = true;
                this.tsmIniciarSesion.Visible = false;
                if(loggedPersona != null)
                {
                    if((loggedPersona.Tipo & Persona.TipoPersona.Alumno) == Persona.TipoPersona.Alumno)
                    {
                        this.tsmAlumno.Visible = true;
                    }
                    if ((loggedPersona.Tipo & Persona.TipoPersona.Alumno) == Persona.TipoPersona.Alumno)
                    {
                        this.tsmAlumno.Visible = true;
                    }
                    if ((loggedPersona.Tipo & Persona.TipoPersona.Docente) == Persona.TipoPersona.Docente)
                    {
                        this.tsmDocente.Visible = true;
                    }
                    if ((loggedPersona.Tipo & Persona.TipoPersona.Bedel) == Persona.TipoPersona.Bedel)
                    {
                        this.tsmPreceptor.Visible = true;
                    }
                    if ((loggedPersona.Tipo & Persona.TipoPersona.Administrador) == Persona.TipoPersona.Administrador)
                    {
                        this.tsmAdministrar.Visible = true;
                    }
                }
            }
        }

        public void LogIn()
        {
            Login login = new Login();
            login.ShowDialog();
            this.loggedUser = login.loggedUser;
            if(loggedUser != null)
            {
                PersonaLogic personas = new PersonaLogic();
                this.loggedPersona = personas.FindByUsuario(this.loggedUser);
            }
            ActualizarVista();
        }

        public void LogOut()
        {
            this.loggedUser = null;
            this.loggedPersona = null;
            ActualizarVista();
            LogIn();
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosList form = new UsuariosList();
            form.Show();
        }

        private void administrarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonasList form = new PersonasList();
            form.Show();
        }

        private void administrarCurrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurriculaList form = new CurriculaList();
            form.Show();
        }

        private void administrarCursadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursadaList form = new CursadaList();
            form.Show();
        }

        private void tsmIniciarSesion_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void tsmCerrarSesion_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void tsmSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            this.ActualizarVista();
            LogIn();
        }

        private void inscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InscripcionList form = new InscripcionList(loggedPersona);
            form.Show();
        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotasAlumnoList form = new NotasAlumnoList(loggedPersona);
            form.Show();
        }
    }
}
