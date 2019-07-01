namespace Parcial2_YersonEscolastico
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rEstudiantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cEstudiantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cAsignaturasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registroToolStripMenuItem,
            this.consultasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEstudiantesToolStripMenuItem,
            this.asignaturasToolStripMenuItem,
            this.inscripcionesToolStripMenuItem});
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.registroToolStripMenuItem.Text = "Registros";
            // 
            // rEstudiantesToolStripMenuItem
            // 
            this.rEstudiantesToolStripMenuItem.Name = "rEstudiantesToolStripMenuItem";
            this.rEstudiantesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.rEstudiantesToolStripMenuItem.Text = "Estudiantes";
            this.rEstudiantesToolStripMenuItem.Click += new System.EventHandler(this.EstudiantesToolStripMenuItem_Click);
            // 
            // asignaturasToolStripMenuItem
            // 
            this.asignaturasToolStripMenuItem.Name = "asignaturasToolStripMenuItem";
            this.asignaturasToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.asignaturasToolStripMenuItem.Text = "Asignaturas";
            this.asignaturasToolStripMenuItem.Click += new System.EventHandler(this.AsignaturasToolStripMenuItem_Click);
            // 
            // inscripcionesToolStripMenuItem
            // 
            this.inscripcionesToolStripMenuItem.Name = "inscripcionesToolStripMenuItem";
            this.inscripcionesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.inscripcionesToolStripMenuItem.Text = "Inscripciones";
            this.inscripcionesToolStripMenuItem.Click += new System.EventHandler(this.InscripcionesToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cEstudiantesToolStripMenuItem,
            this.cAsignaturasToolStripMenuItem1,
            this.inscripcionesToolStripMenuItem1});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // cEstudiantesToolStripMenuItem
            // 
            this.cEstudiantesToolStripMenuItem.Name = "cEstudiantesToolStripMenuItem";
            this.cEstudiantesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cEstudiantesToolStripMenuItem.Text = "Estudiantes";
            this.cEstudiantesToolStripMenuItem.Click += new System.EventHandler(this.CEstudiantesToolStripMenuItem_Click);
            // 
            // cAsignaturasToolStripMenuItem1
            // 
            this.cAsignaturasToolStripMenuItem1.Name = "cAsignaturasToolStripMenuItem1";
            this.cAsignaturasToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cAsignaturasToolStripMenuItem1.Text = "Asignaturas";
            this.cAsignaturasToolStripMenuItem1.Click += new System.EventHandler(this.CAsignaturasToolStripMenuItem1_Click);
            // 
            // inscripcionesToolStripMenuItem1
            // 
            this.inscripcionesToolStripMenuItem1.Name = "inscripcionesToolStripMenuItem1";
            this.inscripcionesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.inscripcionesToolStripMenuItem1.Text = "Inscripciones";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rEstudiantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cEstudiantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cAsignaturasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inscripcionesToolStripMenuItem1;
    }
}

