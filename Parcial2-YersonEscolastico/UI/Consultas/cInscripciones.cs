using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial2_YersonEscolastico.BLL;
using Parcial2_YersonEscolastico.Entidades;
using Tarea6.BLL;

namespace Parcial2_YersonEscolastico.UI.Consultas
{
    public partial class cInscripciones : Form
    {
        public cInscripciones()
        {
            InitializeComponent();
        }

        private void Consultarbutton_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void Consultar()
        {
            var lista = new List<Inscripciones>();
            RepositorioBase<Inscripciones> db = new RepositorioBase<Inscripciones>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                try
                {
                    switch (FiltrocomboBox.SelectedIndex)
                    {
                        case 0:
                            lista = db.GetList(I => true);
                            break;
                        case 1:
                            int id = Convert.ToInt32(CriteriotextBox.Text);
                            lista = db.GetList(I => I.InscripcionId == id);
                            break;

                        case 2:
                            int idtwo = Convert.ToInt32(CriteriotextBox.Text);
                            lista = db.GetList(I => I.EstudianteId == idtwo);
                            break;
                    }
                    lista = lista.Where(T => T.FechaInscripcion >= DesdedateTimePicker.Value.Date && T.FechaInscripcion <= HastadateTimePicker.Value.Date).ToList();
                }
                catch (Exception)
                {

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

