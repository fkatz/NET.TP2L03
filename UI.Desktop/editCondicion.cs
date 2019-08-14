using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop {
    public partial class editCondicion : Form {
        private AlumnoInscripto selectedAlumno;
        public editCondicion(AlumnoInscripto a) {
            this.selectedAlumno = a;
            InitializeComponent();
        }

        private void editCondicion_Load(object sender, EventArgs e) {
            lblAlumno.Text = selectedAlumno.Alumno.NombreCompleto;
            cbxCondicion.SelectedItem = selectedAlumno.Condicion.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            DialogResult confirm = MessageBox.Show("Le está por cambiar la condición al alumno " + selectedAlumno.Alumno.NombreCompleto + "\n¿Está seguro de que desea realizar esta operación?", "Administración Condición", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (confirm == DialogResult.Yes) {
                AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
                AlumnoInscripto.Condiciones c = 0;
                switch (cbxCondicion.SelectedItem) {
                    case "Cursante":
                        c = AlumnoInscripto.Condiciones.Cursante;
                        break;
                    case "Aprobado":
                        c = AlumnoInscripto.Condiciones.Aprobado;
                        break;
                    case "Libre":
                        c = AlumnoInscripto.Condiciones.Libre;
                        break;
                    case "Regular":
                        c = AlumnoInscripto.Condiciones.Regular;
                        break;
                }
                selectedAlumno.Condicion = c;
                selectedAlumno.State = BusinessEntity.States.Modified;
                alumnos.Save(selectedAlumno);
                this.Close();
            }
        }
    }
}
