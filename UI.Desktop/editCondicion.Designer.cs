namespace UI.Desktop {
    partial class editCondicion {
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
            this.lblAlumno = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.cbxCondicion = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblAlumno, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCondicion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxCondicion, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(227, 120);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblAlumno
            // 
            this.lblAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Location = new System.Drawing.Point(105, 35);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(16, 13);
            this.lblAlumno.TabIndex = 2;
            this.lblAlumno.Text = "...";
            this.lblAlumno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(76, 93);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblCondicion
            // 
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCondicion.Location = new System.Drawing.Point(3, 0);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(221, 28);
            this.lblCondicion.TabIndex = 0;
            this.lblCondicion.Text = "Condición para";
            this.lblCondicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxCondicion
            // 
            this.cbxCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxCondicion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxCondicion.FormattingEnabled = true;
            this.cbxCondicion.Items.AddRange(new object[] {
            "Regular",
            "Cursante",
            "Aprobado",
            "Libre"});
            this.cbxCondicion.Location = new System.Drawing.Point(53, 62);
            this.cbxCondicion.Name = "cbxCondicion";
            this.cbxCondicion.Size = new System.Drawing.Size(121, 21);
            this.cbxCondicion.TabIndex = 4;
            // 
            // editCondicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 120);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "editCondicion";
            this.Text = "Modificar Condición";
            this.Load += new System.EventHandler(this.editCondicion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.ComboBox cbxCondicion;
    }
}