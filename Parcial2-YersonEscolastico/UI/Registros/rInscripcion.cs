using Parcial2_YersonEscolastico.BLL;
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
    public partial class rInscripcion : Form
    {
        public List<InscripcionesDetalle> Detalle { get; set; }
        public rInscripcion()
        {
            InitializeComponent();
            LlenarComboBox();
            LLenarComboBoxTwo();
            EstudiantecomboBox.Text = null;
            AsignaturacomboBox.Text = null;
            this.Detalle = new List<InscripcionesDetalle>();
        }

        private void Limpiar()
        {
            IdnumericUpDown.Value = 0;
            MontoInscripciontextBox.Text = string.Empty;
            EstudiantecomboBox.Text = string.Empty;
            AsignaturacomboBox.Text = string.Empty;
            MontonumericUpDown.Value = 0;
            this.Detalle = new List<InscripcionesDetalle>();
            MyErrorProvider.Clear();
            CargarGrid();

        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Inscripciones LlenaClase()
        {
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.Asignaturas = this.Detalle;

            if (IdnumericUpDown.Value == 0)
            {
                inscripcion.EstudianteId = Convert.ToInt32(EstudiantecomboBox.SelectedValue);
            }
            else
            {
                inscripcion.EstudianteId = Convert.ToInt32(EstudiantecomboBox.Text);
            }
            inscripcion.InscripcionId = Convert.ToInt32(IdnumericUpDown.Value);
            inscripcion.MontoCreditos = MontonumericUpDown.Value;
            inscripcion.CalcularMonto();
            inscripcion.FechaInscripcion = FechadateTimePicker.Value;

            return inscripcion;
        }

        private void LlenaCampos(Inscripciones inscripcion)
        {
            IdnumericUpDown.Value = inscripcion.InscripcionId;
            EstudiantecomboBox.Text = inscripcion.EstudianteId.ToString();
            MontoInscripciontextBox.Text = inscripcion.MontoInscripcion.ToString();
            MontonumericUpDown.Value = inscripcion.MontoCreditos;
            FechadateTimePicker.Value = inscripcion.FechaInscripcion;
            this.Detalle = inscripcion.Asignaturas;
            CargarGrid();
        }

        private bool Validar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (string.IsNullOrWhiteSpace(EstudiantecomboBox.Text))
            {
                MyErrorProvider.SetError(EstudiantecomboBox, "Este campo no puede estar vacio");
                EstudiantecomboBox.Focus();
                paso = false;
            }

            if (MontonumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(MontonumericUpDown, "Este campo no puede estar vacio");
                MontonumericUpDown.Focus();
                paso = false;
            }

            if (Detalle.Count == 0)
            {
                MyErrorProvider.SetError(AsignaturacomboBox, "Este campo no puede estar vacio");
                AsignaturacomboBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Inscripciones> db = new RepositorioBase<Inscripciones>();
            Inscripciones inscripcion = db.Buscar((int)IdnumericUpDown.Value);
            return (inscripcion != null);

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Inscripciones inscripcion;
            bool paso = false;

            if (!Validar())
                return;

            inscripcion = LlenaClase();
            inscripcion.CalcularMonto();
            if (IdnumericUpDown.Value == 0)
            {
                paso = InscripcionesBLL.Guardar(inscripcion);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un Estudiante que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = InscripcionesBLL.Modificar(inscripcion);
                MessageBox.Show("Modificado");
            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LlenaClase();
            Limpiar();
        }


        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Inscripciones> db = new RepositorioBase<Inscripciones>();
            int id;
            Inscripciones inscripcion = new Inscripciones();

            int.TryParse(IdnumericUpDown.Text, out id);
            Limpiar();

            inscripcion = db.Buscar(id);

            if (inscripcion != null)
            {
                LlenaCampos(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion no existe");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Inscripciones> db = new RepositorioBase<Inscripciones>();
            MyErrorProvider.Clear();
            int id;
            int.TryParse(IdnumericUpDown.Text, out id);
            Limpiar();
            if (db.Eliminar(id))
            {
                MessageBox.Show("Eliminado");
            }
            else
            {
                MyErrorProvider.SetError(IdnumericUpDown, "No se puede eliminar, porque no existe");
            }
        }


        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();
            Asignaturas asignatura = db.Buscar((int)AsignaturacomboBox.SelectedValue);
            if (detalleDataGridView.DataSource != null)
                this.Detalle = (List<InscripcionesDetalle>)detalleDataGridView.DataSource;



            this.Detalle.Add(new InscripcionesDetalle()
            {
                InscripcionId = (int)IdnumericUpDown.Value,
                AsignaturaId = (int)AsignaturacomboBox.SelectedValue,
                InscripcionDetallesId = 0,
                SubTotal = (asignatura.Creditos * MontonumericUpDown.Value)
            });

            CargarGrid();
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (detalleDataGridView.Rows.Count > 0 && detalleDataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(detalleDataGridView.CurrentRow.Index);
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            detalleDataGridView.DataSource = null;
            detalleDataGridView.DataSource = Detalle;
        }

        private void LlenarComboBox()
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();
            var listado2 = new List<Asignaturas>();
            listado2 = db.GetList(p => true);
            AsignaturacomboBox.DataSource = listado2;
            AsignaturacomboBox.DisplayMember = "Descripcion";
            AsignaturacomboBox.ValueMember = "AsignaturaId";
        }

        private void LLenarComboBoxTwo()
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();
            var listado = new List<Estudiantes>();
            listado = db.GetList(l => true);
            EstudiantecomboBox.DataSource = listado;
            EstudiantecomboBox.DisplayMember = "Nombre";
            EstudiantecomboBox.ValueMember = "EstudianteId";
        }
    }
}
