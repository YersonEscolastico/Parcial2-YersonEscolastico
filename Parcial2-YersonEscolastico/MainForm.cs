using Parcial2_YersonEscolastico.UI.Consultas;
using Parcial2_YersonEscolastico.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2_YersonEscolastico
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEstudiantes est = new rEstudiantes();
            est.StartPosition = FormStartPosition.CenterScreen;
            est.Show();
        }

        private void AsignaturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rAsignaturas asg = new rAsignaturas();
            asg.StartPosition = FormStartPosition.CenterScreen;
            asg.Show();
        }

        private void InscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rInscripcion ins = new rInscripcion();
            ins.Show();
        }

        private void CEstudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEstudiantes est = new cEstudiantes();
            est.Show();
        }
    }
}
