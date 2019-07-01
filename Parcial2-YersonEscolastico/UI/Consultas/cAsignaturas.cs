using Parcial2_YersonEscolastico.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tarea6.BLL;

namespace Parcial2_YersonEscolastico.UI.Consultas
{
    public partial class cAsignaturas : Form
    {
        public cAsignaturas()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            var lista = new List<Asignaturas>();
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                try
                {
                    switch (FiltrocomboBox.SelectedIndex)
                    {
                        case 0:
                            lista = db.GetList(A => true);
                            break;
                        case 1:
                            int id = Convert.ToInt32(CriteriotextBox.Text);
                            lista = db.GetList(p => p.AsignaturaId == id);
                            break;
                        case 2:
                            lista = db.GetList(A => A.Descripcion.Contains(CriteriotextBox.Text));
                            break;
                    }
                }
                catch (Exception)
                {

                }
            }else
             
            if (FiltrocomboBox.Text == string.Empty)
            {
                MessageBox.Show("Filtro esta vacio.");
            }
            else
                 if ((string)FiltrocomboBox.Text != "Todo")
            {
                if (CriteriotextBox.Text == string.Empty)
                {
                    MessageBox.Show("Debe agregar algun criterio");
                }
            }
            else
            {
                lista = db.GetList(p => true);
            }
            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = lista;
        }
    }
}

