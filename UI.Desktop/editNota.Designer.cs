namespace UI.Desktop
{
    partial class editNota
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
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblAlumno = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNota.Location = new System.Drawing.Point(3, 0);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(175, 24);
            this.lblNota.TabIndex = 0;
            this.lblNota.Text = "Nota para";
            this.lblNota.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNota
            // 
            this.txtNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota.Location = new System.Drawing.Point(55, 55);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(70, 20);
            this.txtNota.TabIndex = 1;
            this.txtNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAlumno
            // 
            this.lblAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Location = new System.Drawing.Point(82, 29);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(16, 13);
            this.lblAlumno.TabIndex = 2;
            this.lblAlumno.Text = "...";
            this.lblAlumno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(53, 86);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblAlumno, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNota, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNota, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(181, 113);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // editNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 113);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "editNota";
            this.Text = "editNota";
            this.Load += new System.EventHandler(this.editNota_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}