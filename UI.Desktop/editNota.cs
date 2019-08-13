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
    public partial class editNota : Form
    {
        private AlumnoInscripto selectedAlumno;
        public editNota(AlumnoInscripto alumno)
        {
            this.selectedAlumno = alumno;
            InitializeComponent();
        }

        private void editNota_Load(object sender, EventArgs e)
        {
            lblAlumno.Text = selectedAlumno.Alumno.NombreCompleto;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtNota.Text.Length == 0)
            {
                MessageBox.Show("Escriba una nota");
            }
            else
            {
                try
                {
                    if(int.Parse(txtNota.Text) < 0 || int.Parse(txtNota.Text) > 10)
                    {
                        MessageBox.Show("La nota debe estar entre 0 y 10");
                    }
                    else
                    {
                        DialogResult confirm = MessageBox.Show("Le está por cambiar la nota al alumno " + selectedAlumno.Alumno.NombreCompleto + "\n¿Está seguro de que desea realizar esta operación?", "Administración Nota", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (confirm == DialogResult.Yes)
                        {
                            AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
                            selectedAlumno.Nota = int.Parse(txtNota.Text);
                            selectedAlumno.State = BusinessEntity.States.Modified;
                            alumnos.Save(selectedAlumno);
                            this.Close();
                        }
                    }
                }
                catch (FormatException ef)
                {
                    MessageBox.Show("La nota debe ser un número entero (entre 0 y 10)");
                }
            }
        }
    }
}
