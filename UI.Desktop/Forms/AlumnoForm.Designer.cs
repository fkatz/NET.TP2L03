﻿namespace UI.Desktop.Forms {
    partial class AlumnoForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCondición = new System.Windows.Forms.Label();
            this.lblHorasTotal = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblCurso = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtHorasTotal = new System.Windows.Forms.TextBox();
            this.cmbCondición = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblCondición, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHorasTotal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNota, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNota, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCurso, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtHorasTotal, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbCondición, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(618, 227);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 7);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 32;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(105, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(157, 20);
            this.txtID.TabIndex = 33;
            // 
            // lblCondición
            // 
            this.lblCondición.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCondición.AutoSize = true;
            this.lblCondición.Location = new System.Drawing.Point(3, 34);
            this.lblCondición.Name = "lblCondición";
            this.lblCondición.Size = new System.Drawing.Size(54, 13);
            this.lblCondición.TabIndex = 18;
            this.lblCondición.Text = "Condición";
            // 
            // lblHorasTotal
            // 
            this.lblHorasTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHorasTotal.AutoSize = true;
            this.lblHorasTotal.Location = new System.Drawing.Point(268, 34);
            this.lblHorasTotal.Name = "lblHorasTotal";
            this.lblHorasTotal.Size = new System.Drawing.Size(73, 13);
            this.lblHorasTotal.TabIndex = 27;
            this.lblHorasTotal.Text = "Horas Totales";
            // 
            // lblNota
            // 
            this.lblNota.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(3, 62);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(30, 13);
            this.lblNota.TabIndex = 3;
            this.lblNota.Text = "Nota";
            // 
            // txtNota
            // 
            this.txtNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNota.Location = new System.Drawing.Point(105, 57);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(157, 20);
            this.txtNota.TabIndex = 24;
            // 
            // lblCurso
            // 
            this.lblCurso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurso.AutoSize = true;
            this.lblCurso.Location = new System.Drawing.Point(268, 62);
            this.lblCurso.Name = "lblCurso";
            this.lblCurso.Size = new System.Drawing.Size(37, 13);
            this.lblCurso.TabIndex = 7;
            this.lblCurso.Text = "Curso:";
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.btnCancelar);
            this.flowLayoutPanel1.Controls.Add(this.btnAceptar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 86);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(612, 138);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(534, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(453, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // txtHorasTotal
            // 
            this.txtHorasTotal.Location = new System.Drawing.Point(366, 31);
            this.txtHorasTotal.Name = "txtHorasTotal";
            this.txtHorasTotal.Size = new System.Drawing.Size(202, 20);
            this.txtHorasTotal.TabIndex = 34;
            // 
            // cmbCondición
            // 
            this.cmbCondición.FormattingEnabled = true;
            this.cmbCondición.Items.AddRange(new object[] {
            "Aprobado",
            "Regular",
            "Libre",
            "Cursante"});
            this.cmbCondición.Location = new System.Drawing.Point(105, 31);
            this.cmbCondición.Name = "cmbCondición";
            this.cmbCondición.Size = new System.Drawing.Size(157, 21);
            this.cmbCondición.TabIndex = 35;
            // 
            // AlumnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 227);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlumnoForm";
            this.Text = "AlumnoForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblCondición;
        private System.Windows.Forms.Label lblHorasTotal;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblCurso;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtHorasTotal;
        private System.Windows.Forms.ComboBox cmbCondición;
    }
}