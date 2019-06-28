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

namespace Parcial2_YersonEscolastico.UI.Registros
{
    public partial class rEstudiantes : Form
    {
        public rEstudiantes()
        {
            InitializeComponent();
        }
  
        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
            BalancetextBox.Text = "0";

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Estudiantes LlenarClase()
        {
            Estudiantes estudiante = new Estudiantes();

            estudiante.Nombre = NombretextBox.Text;
            estudiante.EstudianteId = (int)IdnumericUpDown.Value;
            estudiante.FechaIngreso = FechadateTimePicker.Value;
            estudiante.Balance = Decimal.Parse(BalancetextBox.Text);

            return estudiante;
        }

        private void LlenarCampos(Estudiantes estudiante)
        {

            IdnumericUpDown.Value = estudiante.EstudianteId;
            NombretextBox.Text = estudiante.Nombre;
            FechadateTimePicker.Value = estudiante.FechaIngreso;
            BalancetextBox.Text = estudiante.Balance.ToString();

        }


        private bool validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                MyErrorProvider.SetError(NombretextBox, "Este campo no puede estar vacio");
                paso = false;
            }

            if (FechadateTimePicker.Value > DateTime.Now)
            {
                MyErrorProvider.SetError(FechadateTimePicker, "Ingrese fecha de hoy");
                paso = false;
            }

            return paso;
        }


        private void Guadarbutton_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            try
            {
                Estudiantes estudiante = new Estudiantes();
                estudiante = LlenarClase();
                RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();

                if (IdnumericUpDown.Value == 0)
                {
                    db.Guardar(estudiante);
                    MessageBox.Show("Guardado", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    db.Modificar(estudiante);
                    MessageBox.Show("Modificado", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                Limpiar();

            }
            catch (Exception)
            {
                MessageBox.Show("error", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            try
            {

                if (IdnumericUpDown.Value > 0)
                {
                    Estudiantes estudiante = new Estudiantes();
                    if ((estudiante = db.Buscar((int)IdnumericUpDown.Value)) != null)
                    {
                        Limpiar();
                        LlenarCampos(estudiante);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo buscar", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            try
            {
                if (IdnumericUpDown.Value > 0)
                {
                    if (db.Eliminar((int)IdnumericUpDown.Value))
                    {
                        MessageBox.Show("Eliminado", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar", "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("NO se pudo eliminar", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
