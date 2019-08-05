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
    public partial class CursoForm : Form, IEntityForm<Curso>
    {
        public Curso EntidadActual { get; set; }
        FormMode formMode;
        CursoLogic entities = new CursoLogic();
        private CursoForm()
        {
            InitializeComponent();
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
            ComisionLogic comLogic = new ComisionLogic();
            this.cmbComision.DataSource = comLogic.GetAll();
            this.cmbComision.DisplayMember = "NombreComision";
            MateriaLogic matLogic = new MateriaLogic();
            this.cmbMateria.DataSource = matLogic.GetAll();
            this.cmbMateria.DisplayMember = "NombreMateria";
        }
        public CursoForm(FormMode formMode) : this()
        {
            this.formMode = formMode;
        }
        public CursoForm(int id, FormMode formMode) : this()
        {
            this.EntidadActual = entities.GetOne(id);
            this.MapearDeDatos();
            this.formMode = formMode;
        }
        public void MapearADatos()
        {
            Curso oldEntity = this.EntidadActual;
            MateriaLogic materias = new MateriaLogic();
            ComisionLogic comisiones = new ComisionLogic();
            this.EntidadActual = new Curso()
            {
                Materia = materias.GetOne(((Materia)cmbMateria.SelectedItem).ID),
                Comision = comisiones.GetOne(((Comision)cmbComision.SelectedItem).ID),
                Cupo = int.Parse(txtCupo.Text),
                AñoCalendario = int.Parse(txtAñoCalendario.Text)
            };
            if (oldEntity != null)
            {
                this.EntidadActual.ID = oldEntity.ID;
            }
        }
        public void MapearDeDatos()
        {
            // mapping
            txtAñoCalendario.Text = EntidadActual.AñoCalendario.ToString();
            txtCupo.Text = EntidadActual.Cupo.ToString();
            cmbComision.SelectedIndex = cmbComision.FindString(EntidadActual.Comision.Descripcion);
            cmbMateria.SelectedIndex = cmbMateria.FindString(EntidadActual.Materia.Descripcion);
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
            }
        }
        public bool Validar()
        {
            bool valid = true;
            string message = "";
            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            switch (this.formMode)
            {
                case FormMode.Alta:
                    this.Text = "Crear Curso";
                    break;
                case FormMode.Modificación:
                    this.Text = "Modificar Curso";
                    break;

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.GuardarDatos();
            this.Dispose();
        }
    }
}