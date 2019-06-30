﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_YersonEscolastico.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int InscripcionId { get; set; }
        public int EstudianteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public virtual List<InscripcionesDetalle> Asignaturas { get; set; }

        public Inscripciones()
        {
            InscripcionId = 0;
            EstudianteId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            Asignaturas = new List<InscripcionesDetalle>();
        }

        public void CalcularMonto()
        {
            decimal total = 0;

            foreach (var item in Asignaturas)
            {
                total += item.SubTotal;
            }

            Monto = total;
        }
    }
}