﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Desktop
{
    public partial class DocenteForm : Form, IEntityForm<DocenteCurso>
    {
        public DocenteCurso EntidadActual { get; set; }
        FormMode formMode;
        DocenteCursoLogic entities = new DocenteCursoLogic();
        public DocenteForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
            this.cmbCargo.DataSource = new String[]{"Titular","Adjunto","Ayudante"};
            this.cmbCargo.DisplayMember = "Cargo";
        }
        public DocenteForm(FormMode formMode) : this()
        {
            this.formMode = formMode;
        }
        public DocenteForm(int id, FormMode formMode) : this()
        {
            this.EntidadActual = entities.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }
        public void MapearADatos()
        {
            DocenteCurso oldEntity = this.EntidadActual;
            PersonaLogic personas = new PersonaLogic();
            DocenteCurso.TiposCargos tp = 0;
            switch (cmbCargo.SelectedIndex)
            {
                case 0:
                    tp = DocenteCurso.TiposCargos.Titular;
                    break;
                case 1:
                    tp = DocenteCurso.TiposCargos.Adjunto;
                    break;
                case 2:
                    tp = DocenteCurso.TiposCargos.Ayudante;
                    break;
                default:
                    break;
            }
            this.EntidadActual = new DocenteCurso()
            {
                Docente = personas.FindByLegajo(int.Parse(txtLegajo.Text)),
                TipoCargo = tp
            };
            if (oldEntity != null)
            {
                this.EntidadActual.ID = oldEntity.ID;
            }
        }

        public void MapearDeDatos()
        {
            txtLegajo.Text = EntidadActual.Docente.Legajo.ToString();
            cmbCargo.SelectedIndex = cmbCargo.FindString(EntidadActual.TipoCargo.ToString());
            txtID.Text = EntidadActual.ID.ToString();
            switch (this.formMode)
            {
                case FormMode.Modificación:
                case FormMode.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case FormMode.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
            }
        }

        public void GuardarDatos()
        {
            if (Validar())
            {
                this.MapearADatos();
                switch (this.formMode)
                {
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
                entities.Save(EntidadActual);
                this.Close();
            }
        }

        public bool Validar()
        {
            
            bool valid = true;
            string message = "";           
            if (cmbCargo.Text.Length == 0)
            {
                valid = false;
                message += "\nCargo requerido.";
            }

            if (txtLegajo.Text.Length == 0)
            {
                valid = false;
                message += "\nEl campo Legajo es obligatorio.";
            }
            else
            {
                try
                {
                    int.Parse(txtLegajo.Text);
                    try
                    {
                        PersonaLogic p = new PersonaLogic();
                        p.FindByLegajo(int.Parse(txtLegajo.Text));
                    }
                    catch (Exception e)
                    {
                        valid = false;
                        message += "\nEl Legajo no pertenece a ningún alumno.";
                    }
                }
                catch (FormatException ef)
                {
                    valid = false;
                    message += "\nEl legajo debe ser un número entero.";
                }
            }

            if (!valid)
            {
                MessageBox.Show("Error:" + message, "Docente inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComisionForm_Load(object sender, EventArgs e)
        {
            switch (this.formMode)
            {
                case FormMode.Alta:
                    this.Text = "Crear Docente";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Docente";
                    break;

            }
        }
    }
}

