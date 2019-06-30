using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_YersonEscolastico.Entidades
{
    public class InscripcionesDetalle
    {
        [Key]
        public int InscripcionDetallesId { get; set; }
        public int InscripcionId { get; set; }
        public int AsignaturaId { get; set; }
        public decimal SubTotal { get; set; }

        //[ForeignKey("AsignaturaId")]
        //public virtual Asignaturas Asignatura { get; set; }

        public InscripcionesDetalle()
        {
            InscripcionDetallesId = 0;
            InscripcionId = 0;
            AsignaturaId = 0;
            SubTotal = 0;
        }

        public InscripcionesDetalle(int id, int inscripcionId, int asignaturaId, decimal subtotal)
        {
            InscripcionDetallesId = id;
            InscripcionId = inscripcionId;
            AsignaturaId = asignaturaId;
            SubTotal = subtotal;
        }
    }
}
