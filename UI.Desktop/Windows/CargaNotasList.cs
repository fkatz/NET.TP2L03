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
    public partial class CargaNotasList : Form
    {
        private CursoLogic cursos = new CursoLogic();
        private DocenteCursoLogic docentes = new DocenteCursoLogic();
        private AlumnoInscriptoLogic alumnos = new AlumnoInscriptoLogic();

        private Persona currentDocente;
        private Curso currentCurso;
        public CargaNotasList(DocenteCurso docCurso)
        {
            this.currentDocente = docCurso.Docente;
            this.currentCurso = cursos.GetOne(docCurso.Curso.ID);
            InitializeComponent();
            dgvAlumnosCurso.AutoGenerateColumns = false;
            gbxAlumnosCurso.Text += " " + currentCurso.ToString();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
        }

        public void Listar()
        {
            List<AlumnoInscripto> alumnoList = alumnos.ListByCursoAndCondicion(currentCurso, AlumnoInscripto.Condiciones.Regular, AlumnoInscripto.Condiciones.Aprobado, AlumnoInscripto.Condiciones.Libre);
            this.dgvAlumnosCurso.DataSource = alumnoList;
            this.dgvAlumnosCurso.ClearSelection();
            foreach (DataGridViewRow row in dgvAlumnosCurso.Rows)
            {
                AlumnoInscripto alumnoInscripto = (AlumnoInscripto)row.DataBoundItem;
                row.Cells["Alumno"].Value = alumnoInscripto.Alumno.NombreCompleto;
                row.Cells["Nota"].ValueType = typeof(string);
                if (alumnoInscripto.Nota != 0)
                {
                    ((DataGridViewTextBoxCell)row.Cells["Nota"]).ReadOnly = true;
                    row.Cells["Nota"].Value = alumnoInscripto.Nota.ToString();
                }
                if (alumnoInscripto.Condicion == AlumnoInscripto.Condiciones.Aprobado)
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
                else if (alumnoInscripto.Condicion == AlumnoInscripto.Condiciones.Libre)
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }

            }
        }
        private bool Modified()
        {
            List<AlumnoInscripto> alumnos = (List<AlumnoInscripto>)dgvAlumnosCurso.DataSource;
            bool modified = false;
            foreach (AlumnoInscripto alumno in alumnos)
            {
                if (alumno.State == BusinessEntity.States.Modified)
                {
                    modified = true;
                    break;
                }
            }
            return modified;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

            if (Modified())
            {
                DialogResult confirm = MessageBox.Show("Ha realizado cambios ¿Desea descartarlos y salir?", "Descartar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (confirm == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else { this.Close(); }
        }

        private void AlumnosCursoList_Load(object sender, EventArgs e)
        {
            Listar();
            if(currentCurso.AñoCalendario < DateTime.Now.Year)
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
            if (Modified())
            {
                DialogResult confirm = MessageBox.Show("Una vez guardada una nota, no podrá modificarla ¿Desea confirmar esta operación?", "Confirmar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (confirm == DialogResult.Yes)
                {
                    List<AlumnoInscripto> alumnosList = (List<AlumnoInscripto>)dgvAlumnosCurso.DataSource;
                    foreach (AlumnoInscripto alumno in alumnosList)
                    {
                        if (alumno.State == BusinessEntity.States.Modified)
                        {
                            if (alumno.Nota >= 6)
                            {
                                alumno.Condicion = AlumnoInscripto.Condiciones.Aprobado;
                            }
                            else alumno.Condicion = AlumnoInscripto.Condiciones.Libre;
                            alumnos.Save(alumno);
                            alumno.State = BusinessEntity.States.Unmodified;
                        }
                    }
                    this.Close();
                }
            }
            else this.Close(); 
        }

        private void dgvAlumnosCurso_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AlumnoInscripto alumno = (AlumnoInscripto)dgvAlumnosCurso.Rows[e.RowIndex].DataBoundItem;
            try
            {

                if (dgvAlumnosCurso["Nota", e.RowIndex].ValueType == typeof(string))
                {
                    string value = (string)dgvAlumnosCurso["Nota", e.RowIndex].Value;
                    if (value != null)
                    {
                        int nota = int.Parse(value);
                        if (nota < 1 || nota > 10) throw new FormatException();
                        alumno.Nota = nota;
                        alumno.State = BusinessEntity.States.Modified;
                    }
                    else
                    {
                        alumno.Nota = 0;
                        alumno.State = BusinessEntity.States.Unmodified;
                    }
                }
                else throw new FormatException();
            }
            catch (FormatException)
            {
                MessageBox.Show("La nota debe ser un número entero entre 1 y 10", "Formato de nota incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string newValue = alumno.Nota == 0 ? "" : alumno.Nota.ToString();
                dgvAlumnosCurso["Nota", e.RowIndex].Value = newValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la nota. Detalle:" + ex.ToString(), "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAlumnosCurso_SelectionChanged(object sender, EventArgs e)
        {
            dgvAlumnosCurso.ClearSelection();
        }
    }
}
