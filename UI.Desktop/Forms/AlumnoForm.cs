﻿using System;
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
using Data.Database;

namespace UI.Desktop.Forms {
    public partial class AlumnoForm : Form, IEntityForm<AlumnoInscripto> {
        public AlumnoInscripto EntidadActual { get; set; }
        FormMode formMode;
        AlumnoInscriptoLogic entities = new AlumnoInscriptoLogic();
        PersonaLogic personas = new PersonaLogic();
        Curso currentCurso;
        public AlumnoForm(Curso curso) {
            this.currentCurso = curso;
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
            txtCurso.Text = curso.ToString();
        }
        public AlumnoForm(FormMode formMode, Curso curso) : this(curso) {
            this.formMode = formMode;
        }
        public AlumnoForm(int id, FormMode formMode, Curso curso) : this(curso) {
            this.EntidadActual = entities.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }
        public void GuardarDatos() {
            if (Validar()) {
                this.MapearADatos();
                switch (this.formMode) {
                    case FormMode.Alta:
                        EntidadActual.State = BusinessEntity.States.New;
                        break;
                    case FormMode.Modificación:
                        EntidadActual.State = BusinessEntity.States.Modified;
                        break;
                    case FormMode.Baja:
                        EntidadActual.State = BusinessEntity.States.Deleted;
                        break;
                }
                try
                {
                    entities.Save(EntidadActual);
                    this.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void MapearADatos() {
            AlumnoInscripto oldEntity = this.EntidadActual;
            AlumnoInscripto.Condiciones c = 0;
            switch (cmbCondicion.SelectedItem) {
                case "Regular":
                    c = AlumnoInscripto.Condiciones.Regular;
                    break;
                case "Libre":
                    c = AlumnoInscripto.Condiciones.Libre;
                    break;
                case "Aprobado":
                    c = AlumnoInscripto.Condiciones.Aprobado;
                    break;
                case "Cursante":
                    c = AlumnoInscripto.Condiciones.Cursante;
                    break;
            }
            Persona alumno = personas.FindByLegajo(int.Parse(txtLegajo.Text));
            int nota = 0;
            if (txtNota.Text.Length > 0) nota = int.Parse(txtNota.Text);
            this.EntidadActual = new AlumnoInscripto() {
                Condicion =  c,
                Alumno = alumno,
                Nota = nota,
                Curso = currentCurso
            };
            if (oldEntity != null) {
                this.EntidadActual.ID = oldEntity.ID;
            }
        }

        public void MapearDeDatos() {
            txtLegajo.Text = EntidadActual.Alumno.Legajo.ToString();
            if (EntidadActual.Nota > 0)
            {
                txtNota.Text = EntidadActual.Nota.ToString();
            }
            else txtNota.Text = "";
            cmbCondicion.SelectedItem = EntidadActual.Condicion.ToString();
            txtID.Text = EntidadActual.ID.ToString();
            switch (this.formMode) {
                case FormMode.Modificación:
                case FormMode.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case FormMode.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
            SetPersona();

        }

        public bool Validar() {
            bool valid = true;
            string message = "";
            if (txtLegajo.Text.Length == 0) {
                valid = false;
                message += "\nEl campo Legajo es obligatorio.";
            }
            else {
                try {
                    int.Parse(txtLegajo.Text);
                    try {
                        personas.FindByLegajo(int.Parse(txtLegajo.Text));
                    }
                    catch (Exception e) {
                        valid = false;
                        message += "\nEl Legajo no pertenece a ningún alumno.";
                    }
                }
                catch (FormatException ef) {
                    valid = false;
                    message += "\nEl legajo debe ser un número entero.";
                }
            }

            if (txtNota.Text.Length > 0) {
                try {
                    int.Parse(txtNota.Text);
                }
                catch (FormatException ef) {
                    valid = false;
                    message += "\nEl Nota debe ser un número entero.";
                }
            }

            if (cmbCondicion.Text.Length == 0) {
                valid = false;
                message += "\nEl campo Condicion es obligatorio.";
            }
            else if(cmbCondicion.Text != "Aprobado" && cmbCondicion.Text != "Cursante" && cmbCondicion.Text != "Regular" && cmbCondicion.Text != "Libre") {
                valid = false;
                message += "\nCondición inválida.";
            }
            if (!valid) {
                MessageBox.Show("Error:" + message, "Alumno inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            this.GuardarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void AlumnoForm_Load(object sender, EventArgs e) {
            switch (this.formMode) {
                case FormMode.Alta:
                    this.Text = "Crear Alumno Inscripto";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Alumno Inscripto";
                    break;

            }
        }
        private void SetPersona()
        {
            try
            {
                Persona p = personas.FindByLegajo(int.Parse(txtLegajo.Text));
                if (p != null)
                {
                    txtAlumno.Text = p.ToString();
                }
                else
                {
                    throw new Exception("Persona no encontrada");
                }
            }
            catch
            {
                txtAlumno.Text = "";
            }
    }

        private void txtLegajo_TextChanged(object sender, EventArgs e)
        {
            SetPersona();
        }
           
    }
}
