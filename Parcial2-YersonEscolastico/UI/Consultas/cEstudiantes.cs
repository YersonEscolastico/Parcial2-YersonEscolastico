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
    public partial class cEstudiantes : Form
    {
        public cEstudiantes()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            var lista = new List<Estudiantes>();
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();

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
                            lista = db.GetList(E => E.EstudianteId == id);
                            break;
                        case 2:
                            lista = db.GetList(E => E.Nombre.Contains(CriteriotextBox.Text));
                            break;
                    }
                    lista = lista.Where(E => E.FechaIngreso >= DesdedateTimePicker.Value.Date && E.FechaIngreso <= HastadateTimePicker.Value.Date).ToList();
                }
                catch (Exception)
                { }  
            }
            else

            if (FiltrocomboBox.Text == string.Empty)
            {
                MessageBox.Show("El campo filtro no puede estar vacio.");
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

