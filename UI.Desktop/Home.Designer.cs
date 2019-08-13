namespace UI.Desktop
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be Dispose()d; otherwise, false.</param>
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdministrar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdmUs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdmPer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdmCurr = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdmCurs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDocente = new System.Windows.Forms.ToolStripMenuItem();
            this.administrarNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPreceptor = new System.Windows.Forms.ToolStripMenuItem();
            this.regularidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmArchivo,
            this.tsmAdministrar,
            this.tsmAlumno,
            this.tsmDocente,
            this.tsmPreceptor});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmArchivo
            // 
            this.tsmArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmIniciarSesion,
            this.tsmCerrarSesion,
            this.tsmSalir});
            this.tsmArchivo.Name = "tsmArchivo";
            this.tsmArchivo.Size = new System.Drawing.Size(60, 20);
            this.tsmArchivo.Text = "Archivo";
            // 
            // tsmIniciarSesion
            // 
            this.tsmIniciarSesion.Name = "tsmIniciarSesion";
            this.tsmIniciarSesion.Size = new System.Drawing.Size(143, 22);
            this.tsmIniciarSesion.Text = "Iniciar Sesión";
            this.tsmIniciarSesion.Click += new System.EventHandler(this.tsmIniciarSesion_Click);
            // 
            // tsmCerrarSesion
            // 
            this.tsmCerrarSesion.Name = "tsmCerrarSesion";
            this.tsmCerrarSesion.Size = new System.Drawing.Size(143, 22);
            this.tsmCerrarSesion.Text = "Cerrar Sesión";
            this.tsmCerrarSesion.Click += new System.EventHandler(this.tsmCerrarSesion_Click);
            // 
            // tsmSalir
            // 
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.Size = new System.Drawing.Size(143, 22);
            this.tsmSalir.Text = "Salir";
            this.tsmSalir.Click += new System.EventHandler(this.tsmSalir_Click);
            // 
            // tsmAdministrar
            // 
            this.tsmAdministrar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdmUs,
            this.tsmAdmPer,
            this.tsmAdmCurr,
            this.tsmAdmCurs});
            this.tsmAdministrar.Name = "tsmAdministrar";
            this.tsmAdministrar.Size = new System.Drawing.Size(81, 20);
            this.tsmAdministrar.Text = "Administrar";
            // 
            // tsmAdmUs
            // 
            this.tsmAdmUs.Name = "tsmAdmUs";
            this.tsmAdmUs.Size = new System.Drawing.Size(187, 22);
            this.tsmAdmUs.Text = "Administrar Usuarios";
            this.tsmAdmUs.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
            // 
            // tsmAdmPer
            // 
            this.tsmAdmPer.Name = "tsmAdmPer";
            this.tsmAdmPer.Size = new System.Drawing.Size(187, 22);
            this.tsmAdmPer.Text = "Administrar Personas";
            this.tsmAdmPer.Click += new System.EventHandler(this.administrarPersonasToolStripMenuItem_Click);
            // 
            // tsmAdmCurr
            // 
            this.tsmAdmCurr.Name = "tsmAdmCurr";
            this.tsmAdmCurr.Size = new System.Drawing.Size(187, 22);
            this.tsmAdmCurr.Text = "Administrar Currícula";
            this.tsmAdmCurr.Click += new System.EventHandler(this.administrarCurrículaToolStripMenuItem_Click);
            // 
            // tsmAdmCurs
            // 
            this.tsmAdmCurs.Name = "tsmAdmCurs";
            this.tsmAdmCurs.Size = new System.Drawing.Size(187, 22);
            this.tsmAdmCurs.Text = "Administrar Cursada";
            this.tsmAdmCurs.Click += new System.EventHandler(this.administrarCursadaToolStripMenuItem_Click);
            // 
            // tsmAlumno
            // 
            this.tsmAlumno.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inscripcionesToolStripMenuItem,
            this.notasToolStripMenuItem});
            this.tsmAlumno.Name = "tsmAlumno";
            this.tsmAlumno.Size = new System.Drawing.Size(62, 20);
            this.tsmAlumno.Text = "Alumno";
            // 
            // inscripcionesToolStripMenuItem
            // 
            this.inscripcionesToolStripMenuItem.Name = "inscripcionesToolStripMenuItem";
            this.inscripcionesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.inscripcionesToolStripMenuItem.Text = "Inscripciones";
            this.inscripcionesToolStripMenuItem.Click += new System.EventHandler(this.inscripcionesToolStripMenuItem_Click);
            // 
            // notasToolStripMenuItem
            // 
            this.notasToolStripMenuItem.Name = "notasToolStripMenuItem";
            this.notasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.notasToolStripMenuItem.Text = "Estado Académico";
            this.notasToolStripMenuItem.Click += new System.EventHandler(this.notasToolStripMenuItem_Click);
            // 
            // tsmDocente
            // 
            this.tsmDocente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administrarNotasToolStripMenuItem});
            this.tsmDocente.Name = "tsmDocente";
            this.tsmDocente.Size = new System.Drawing.Size(63, 20);
            this.tsmDocente.Text = "Docente";
            // 
            // administrarNotasToolStripMenuItem
            // 
            this.administrarNotasToolStripMenuItem.Name = "administrarNotasToolStripMenuItem";
            this.administrarNotasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.administrarNotasToolStripMenuItem.Text = "Administrar Notas";
            this.administrarNotasToolStripMenuItem.Click += new System.EventHandler(this.administrarNotasToolStripMenuItem_Click);
            // 
            // tsmPreceptor
            // 
            this.tsmPreceptor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularidadesToolStripMenuItem});
            this.tsmPreceptor.Name = "tsmPreceptor";
            this.tsmPreceptor.Size = new System.Drawing.Size(48, 20);
            this.tsmPreceptor.Text = "Bedel";
            // 
            // regularidadesToolStripMenuItem
            // 
            this.regularidadesToolStripMenuItem.Name = "regularidadesToolStripMenuItem";
            this.regularidadesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.regularidadesToolStripMenuItem.Text = "Regularidades";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 426);
            this.panel1.TabIndex = 4;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.Text = "Home";
            this.Shown += new System.EventHandler(this.Home_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmIniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmAdministrar;
        private System.Windows.Forms.ToolStripMenuItem tsmAdmPer;
        private System.Windows.Forms.ToolStripMenuItem tsmAdmCurr;
        private System.Windows.Forms.ToolStripMenuItem tsmAdmUs;
        private System.Windows.Forms.ToolStripMenuItem tsmAdmCurs;
        private System.Windows.Forms.ToolStripMenuItem tsmAlumno;
        private System.Windows.Forms.ToolStripMenuItem inscripcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDocente;
        private System.Windows.Forms.ToolStripMenuItem administrarNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmPreceptor;
        private System.Windows.Forms.ToolStripMenuItem regularidadesToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}