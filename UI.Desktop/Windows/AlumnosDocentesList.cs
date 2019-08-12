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
using UI.Desktop.Forms;

namespace UI.Desktop
{
    public partial class AlumnosDocentesList : Form
    {
        public AlumnosDocentesList(Curso curso) :this()
        {
            this.currentCurso = curso;
            this.Text = "Administrar curso " + curso.Comision.ToString() + " " + curso.AñoCalendario.ToString();
        }
        private Curso currentCurso;
        private MateriaLogic materias = new MateriaLogic();
        private PlanLogic planes = new PlanLogic();
        public AlumnosDocentesList()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            this.dgvPlanes.DataSource = planes.GetAll();
            this.dgvMaterias.DataSource = materias.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            Form entityForm;
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPlanes":
                    entityForm = new PlanForm(FormMode.Alta);
                    break;
                case "tabMaterias":
                    entityForm = new MateriaForm(FormMode.Alta);
                    break;
                case "tsbAlumnos":
                    entityForm = new AlumnoForm(FormMode.Alta);
                    break;
                default: throw new Exception("No tab selected");
            }
            entityForm.ShowDialog();
            Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            Form entityForm;
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPlanes":
                    entityForm = new PlanForm(((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                case "tabMaterias":
                    entityForm = new MateriaForm(((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID, FormMode.Modificación);
                    break;
                //COMPLETAR
                default: throw new Exception("No tab selected");
            }
            entityForm.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Está seguro de que desea eliminar los elementos seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (confirm == DialogResult.Yes)
            {
                try {
                    if (tabControl.SelectedTab == tsbAlumnos) {
                        List<Plan> array = new List<Plan>();
                        foreach (DataGridViewRow row in dgvPlanes.SelectedRows) {
                            Plan entity = (Plan)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            planes.Save(entity);
                        }
                    }

                    else if (tabControl.SelectedTab == tsbDocentes) {
                        List<Materia> array = new List<Materia>();
                        foreach (DataGridViewRow row in dgvMaterias.SelectedRows) {
                            Materia entity = (Materia)row.DataBoundItem;
                            entity.State = BusinessEntity.States.Deleted;
                            materias.Save(entity);
                        }
                    }
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    switch (ex.InnerException)
                    {
                        case System.Data.Entity.Core.UpdateException ue:
                            MessageBox.Show("No se ha podido eliminar un elemento ya que está referenciado por otro elemento", "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                            break;
                    }
                }
                finally
                {
                    Listar();
                }
            }
        }

        private void selectionChanged(object sender, EventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            tsbEditar.Enabled = grid.SelectedRows.Count == 1;
        }
    }
}