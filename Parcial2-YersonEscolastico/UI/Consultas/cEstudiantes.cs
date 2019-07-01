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
            var listado = new List<Estudiantes>();
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            if (FiltroFechacheckBox.Checked == true)
            {
                try
                {
                    if (CriteriotextBox.Text.Trim().Length > 0)
                    {
                        switch (FiltrocomboBox.Text)
                        {
                            case "Todo":
                                listado = db.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriteriotextBox.Text);
                                listado = db.GetList(p => p.EstudianteId == id);
                                break;

                            case "Nombre":
                                listado = db.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                                break;

                            case "Balance":
                                decimal monto = Convert.ToInt32(CriteriotextBox.Text);
                                listado = db.GetList(p => p.Balance == monto);
                                break;

                            default:
                                break;
                        }
                        listado = listado.Where(c => c.FechaIngreso.Date >= DesdedateTimePicker.Value.Date && c.FechaIngreso.Date <= HastadateTimePicker.Value.Date).ToList();
                    }
                    else
                    {
                        listado = db.GetList(p => true);
                        listado = listado.Where(c => c.FechaIngreso.Date >= DesdedateTimePicker.Value.Date && c.FechaIngreso.Date <= HastadateTimePicker.Value.Date).ToList();
                    }
                    ConsultadataGridView.DataSource = null;
                    ConsultadataGridView.DataSource = listado;
                }
                catch (Exception)
                { }
            }
            else
            {
                try
                {

                    if (CriteriotextBox.Text.Trim().Length > 0)
                    {
                        switch (FiltrocomboBox.Text)
                        {
                            case "Todo":
                                listado = db.GetList(p => true);
                                break;

                            case "Id":
                                int id = Convert.ToInt32(CriteriotextBox.Text);
                                listado = db.GetList(p => p.EstudianteId == id);
                                break;

                            case "Nombre":
                                listado = db.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                                break;

                            case "Balance":
                                decimal monto = Convert.ToInt32(CriteriotextBox.Text);
                                listado = db.GetList(p => p.Balance == monto);
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (FiltrocomboBox.Text == string.Empty)
                        {
                            MessageBox.Show("Filtro esta vacio");
                        }
                        else
                            if ((string)FiltrocomboBox.Text != "Todo")
                        {
                            if (CriteriotextBox.Text == string.Empty)
                            {
                                MessageBox.Show("Criterio no puede estar vacio");
                            }
                        }
                        else
                        {
                            listado = db.GetList(p => true);
                        }
                        ConsultadataGridView.DataSource = null;
                        ConsultadataGridView.DataSource = listado;
                    }
                }
                catch (Exception)
                { }
            }
        }
    }
}

