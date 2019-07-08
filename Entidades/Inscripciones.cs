using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public decimal MontoInscripcion { get; set; }
        public decimal MontoCreditos { get; set; }
        public int EstudianteId { get; set; }

        public virtual List<InscripcionesDetalle> Asignaturas { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            EstudianteId = 0;
            FechaInscripcion = DateTime.Now;
            MontoCreditos = 0;
            Asignaturas = new List<InscripcionesDetalle>();
        }

        public void CalcularMonto()
        {
            decimal total = 0;

            foreach (var item in Asignaturas)
            {
                total += item.SubTotal;
            }

            MontoInscripcion = total;
        }
    }
}
