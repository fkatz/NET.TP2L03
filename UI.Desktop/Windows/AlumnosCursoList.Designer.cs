namespace UI.Desktop.Windows
{
    partial class AlumnosCursoList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxAlumnosCurso = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAlumnosCurso = new System.Windows.Forms.DataGridView();
            this.Alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNota = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxAlumnosCurso.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosCurso)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbxAlumnosCurso, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.62273F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.686937F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(660, 370);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // gbxAlumnosCurso
            // 
            this.gbxAlumnosCurso.Controls.Add(this.panel1);
            this.gbxAlumnosCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxAlumnosCurso.Location = new System.Drawing.Point(3, 3);
            this.gbxAlumnosCurso.Name = "gbxAlumnosCurso";
            this.gbxAlumnosCurso.Padding = new System.Windows.Forms.Padding(5);
            this.gbxAlumnosCurso.Size = new System.Drawing.Size(654, 324);
            this.gbxAlumnosCurso.TabIndex = 3;
            this.gbxAlumnosCurso.TabStop = false;
            this.gbxAlumnosCurso.Text = "Alumnos de";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvAlumnosCurso);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 301);
            this.panel1.TabIndex = 3;
            // 
            // dgvAlumnosCurso
            // 
            this.dgvAlumnosCurso.AllowUserToAddRows = false;
            this.dgvAlumnosCurso.AllowUserToDeleteRows = false;
            this.dgvAlumnosCurso.AllowUserToResizeRows = false;
            this.dgvAlumnosCurso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlumnosCurso.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAlumnosCurso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlumnosCurso.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvAlumnosCurso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAlumnosCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnosCurso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Alumno,
            this.Condicion,
            this.Nota});
            this.dgvAlumnosCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnosCurso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAlumnosCurso.Location = new System.Drawing.Point(0, 0);
            this.dgvAlumnosCurso.MultiSelect = false;
            this.dgvAlumnosCurso.Name = "dgvAlumnosCurso";
            this.dgvAlumnosCurso.ReadOnly = true;
            this.dgvAlumnosCurso.RowHeadersVisible = false;
            this.dgvAlumnosCurso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlumnosCurso.ShowEditingIcon = false;
            this.dgvAlumnosCurso.Size = new System.Drawing.Size(642, 299);
            this.dgvAlumnosCurso.TabIndex = 2;
            this.dgvAlumnosCurso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnosCurso_CellClick);
            // 
            // Alumno
            // 
            this.Alumno.HeaderText = "Alumno";
            this.Alumno.Name = "Alumno";
            this.Alumno.ReadOnly = true;
            // 
            // Condicion
            // 
            this.Condicion.DataPropertyName = "Condicion";
            this.Condicion.HeaderText = "Condicion";
            this.Condicion.Name = "Condicion";
            this.Condicion.ReadOnly = true;
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            this.Nota.ReadOnly = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnOk);
            this.flowLayoutPanel2.Controls.Add(this.btnNota);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 333);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(654, 34);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // btnNota
            // 
            this.btnNota.Location = new System.Drawing.Point(484, 3);
            this.btnNota.Name = "btnNota";
            this.btnNota.Size = new System.Drawing.Size(86, 23);
            this.btnNota.TabIndex = 0;
            this.btnNota.Text = "Modificar Nota";
            this.btnNota.UseVisualStyleBackColor = true;
            this.btnNota.Click += new System.EventHandler(this.btnNota_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOk.Location = new System.Drawing.Point(576, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AlumnosCursoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 370);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlumnosCursoList";
            this.Text = "AlumnosCursoList";
            this.Load += new System.EventHandler(this.AlumnosCursoList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbxAlumnosCurso.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosCurso)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxAlumnosCurso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAlumnosCurso;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
        private System.Windows.Forms.Button btnNota;
    }
}