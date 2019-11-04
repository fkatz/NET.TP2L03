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
                if(loggedUser != null && loggedUser.Persona != null)
                {
                    if((loggedUser.Persona.Tipo & Persona.TipoPersona.Alumno) == Persona.TipoPersona.Alumno)
                    {
                        this.tsmAlumno.Visible = true;
                    }
                    if ((loggedUser.Persona.Tipo & Persona.TipoPersona.Alumno) == Persona.TipoPersona.Alumno)
                    {
                        this.tsmAlumno.Visible = true;
                    }
                    if ((loggedUser.Persona.Tipo & Persona.TipoPersona.Docente) == Persona.TipoPersona.Docente)
                    {
                        this.tsmDocente.Visible = true;
                    }
                    if ((loggedUser.Persona.Tipo & Persona.TipoPersona.Bedel) == Persona.TipoPersona.Bedel)
                    {
                        this.tsmPreceptor.Visible = true;
                    }
                    if ((loggedUser.Persona.Tipo & Persona.TipoPersona.Administrador) == Persona.TipoPersona.Administrador)
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
            ActualizarVista();
        }

        public void LogOut()
        {
            this.loggedUser = null;
            ActualizarVista();
            LogIn();
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.UsuariosList form = new Windows.UsuariosList();
            form.Show();
        }

        private void administrarPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.PersonasList form = new Windows.PersonasList();
            form.Show();
        }

        private void administrarCurrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.CurriculaList form = new Windows.CurriculaList();
            form.Show();
        }

        private void administrarCursadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.CursadaList form = new Windows.CursadaList();
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
            Windows.InscripcionList form = new Windows.InscripcionList(loggedUser.Persona);
            form.Show();
        }

        private void notasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.NotasAlumnoList form = new Windows.NotasAlumnoList(loggedUser.Persona);
            form.Show();
        }

        private void administrarNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.CursosDocenteList form = new Windows.CursosDocenteList(loggedUser.Persona);
            form.Show();
        }

        private void regularidadesToolStripMenuItem_Click(object sender, EventArgs e) {
            Windows.RegularidadesBedelList form = new Windows.RegularidadesBedelList();
            form.Show();
        }

        private void consultarPromediosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.Promedios form = new Windows.Promedios();
            form.Show();
        }

        private void asistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Windows.ListadoAsistencia a = new Windows.ListadoAsistencia(loggedUser.Persona);
            a.Show();
        }
    }
}
