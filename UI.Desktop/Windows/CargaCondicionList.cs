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

namespace UI.Desktop.Windows
{
    public partial class CargaCondicionList : Form
    {
        private CursoLogic cursos = new CursoLogic();
        private AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();
        private Curso currentCurso;
        public CargaCondicionList(Curso curso)
        {
            this.currentCurso = curso;
            InitializeComponent();
            dgvAlumnosCurso.AutoGenerateColumns = false;
            gbxAlumnosCurso.Text += " " + currentCurso.ToString();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
        }

        public void Listar()
        {
            List<AlumnoInscripto> alumnoList = alumnos.ListByCurso(currentCurso);
            this.dgvAlumnosCurso.DataSource = alumnoList;
            this.dgvAlumnosCurso.ClearSelection();
            foreach (DataGridViewRow row in dgvAlumnosCurso.Rows)
            {
                AlumnoInscripto alumnoInscripto = (AlumnoInscripto)row.DataBoundItem;
                row.Cells["Alumno"].Value = alumnoInscripto.Alumno.NombreCompleto;
                row.Cells["Legajo"].Value = alumnoInscripto.Alumno.Legajo.ToString();

                switch (alumnoInscripto.Condicion)
                {
                    case AlumnoInscripto.Condiciones.Cursante:
                        row.Cells["Condicion"].Value = "Cursante";
                        break;
                    case AlumnoInscripto.Condiciones.Libre:
                        row.Cells["Condicion"].Value = "Libre";
                        break;
                    case AlumnoInscripto.Condiciones.Regular:
                        row.Cells["Condicion"].Value = "Regular";
                        break;
                    case AlumnoInscripto.Condiciones.Aprobado:
                        row.Cells["Condicion"].Value = "Aprobado";
                        break;
                }

                if (alumnoInscripto.Nota != 0)
                {
                    row.Cells["Condicion"].ReadOnly = true;
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlumnosCursoList_Load(object sender, EventArgs e)
        {
            Listar();
            if (currentCurso.AñoCalendario < DateTime.Now.Year)
            {
            }
            else
            {
            }
        }

        private void editNota_FormClosing(object sender, FormClosingEventArgs e)
        {
            Listar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<AlumnoInscripto> alumnosList = (List<AlumnoInscripto>)dgvAlumnosCurso.DataSource;
            foreach (AlumnoInscripto alumno in alumnosList)
            {
                if (alumno.State == BusinessEntity.States.Modified)
                {
                    alumnos.Save(alumno);
                    alumno.State = BusinessEntity.States.Unmodified;
                }
            }
            this.Close();
        }

        private void dgvAlumnosCurso_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AlumnoInscripto alumno = (AlumnoInscripto)dgvAlumnosCurso.Rows[e.RowIndex].DataBoundItem;
            if (dgvAlumnosCurso.Columns[e.ColumnIndex].Name == "Condicion")
            {
                string condString = (string)dgvAlumnosCurso.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (condString != "Aprobado")
                {
                    AlumnoInscripto.Condiciones condicion;
                    switch (condString)
                    {
                        case "Cursante":
                            condicion = AlumnoInscripto.Condiciones.Cursante;
                            break;
                        case "Libre":
                            condicion = AlumnoInscripto.Condiciones.Libre;
                            break;
                        case "Regular":
                            condicion = AlumnoInscripto.Condiciones.Regular;
                            break;
                        default:
                            throw new Exception("Bad option");
                    }
                    alumno.Condicion = condicion;
                    alumno.State = BusinessEntity.States.Modified;
                }
                else
                {
                    MessageBox.Show("Esta condición no puede ser seleccionada manualmente.", "Opción inválida");
                    switch (alumno.Condicion)
                    {
                        case AlumnoInscripto.Condiciones.Cursante:
                            dgvAlumnosCurso.Rows[e.RowIndex].Cells["Condicion"].Value = "Cursante";
                            break;
                        case AlumnoInscripto.Condiciones.Libre:
                            dgvAlumnosCurso.Rows[e.RowIndex].Cells["Condicion"].Value = "Libre";
                            break;
                        case AlumnoInscripto.Condiciones.Regular:
                            dgvAlumnosCurso.Rows[e.RowIndex].Cells["Condicion"].Value = "Regular";
                            break;
                        case AlumnoInscripto.Condiciones.Aprobado:
                            dgvAlumnosCurso.Rows[e.RowIndex].Cells["Condicion"].Value = "Aprobado";
                            break;
                    }
                }
            }

        }

        private void dgvAlumnosCurso_SelectionChanged(object sender, EventArgs e)
        {
            dgvAlumnosCurso.ClearSelection();
        }
    }
}
