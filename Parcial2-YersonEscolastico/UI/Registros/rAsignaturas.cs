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
    public partial class rAsignaturas : Form
    {
        public rAsignaturas()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            CreditosnumericUpDown.Value = 0;
            MyErrorProvider.Clear();

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Asignaturas LlenarClase()
        {
            Asignaturas asignatura = new Asignaturas();

            asignatura.AsignaturaId = (int)IdnumericUpDown.Value;
            asignatura.Descripcion = DescripciontextBox.Text;
            asignatura.Creditos = (int)CreditosnumericUpDown.Value;

            return asignatura;
        }
        

        private void LlenarCampos(Asignaturas asignatura)
        {
            IdnumericUpDown.Value = asignatura.AsignaturaId;
            DescripciontextBox.Text = asignatura.Descripcion;
            CreditosnumericUpDown.Value = asignatura.Creditos;

        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                MyErrorProvider.SetError(DescripciontextBox, "Este campo no puede estar vacio");
                paso = false;
            }

            if (CreditosnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CreditosnumericUpDown, "Debe ser mayor que cero");
                paso = false;

            }

            if (CreditosnumericUpDown.Value > 5)
            {
                MyErrorProvider.SetError(CreditosnumericUpDown, "No puede ser mayor que 5");
                paso = false;

            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
            Asignaturas asignaturas = db.Buscar((int)IdnumericUpDown.Value);
            return (asignaturas!= null);
        }

        private void Guadarbutton_Click_1(object sender, EventArgs e)
        {

            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
            Asignaturas asignaturas;
            bool paso = false;

            if (!Validar())
                return;

            asignaturas = LlenarClase();


            if (IdnumericUpDown.Value == 0)
            {
                paso = db.Guardar(asignaturas);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Estudiante que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = db.Modificar(asignaturas);

            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }


        private void Buscarbutton_Click_1(object sender, EventArgs e)
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
            try
            {

                if (IdnumericUpDown.Value > 0)
                {
                    Asignaturas asignaturas = new Asignaturas();
                    if ((asignaturas = db.Buscar((int)IdnumericUpDown.Value)) != null)
                    {
                        Limpiar();
                        LlenarCampos(asignaturas);
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


        private void Eliminarbutton_Click_1(object sender, EventArgs e)
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>(new DAL.Contexto());
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
