using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea6.BLL;

namespace Parcial2_YersonEscolasticoTests2.BLL
{
    [TestClass()]
    public class InscripcionesTests
    {
        [TestMethod()]
        public void InscripcionGuardarTest()
        {
            Inscripciones inscripcion = new Inscripciones();
            inscripcion.InscripcionId = 1;
            inscripcion.EstudianteId = 1;
            inscripcion.FechaInscripcion = DateTime.Now;
            inscripcion.MontoCreditos = 200;

            RepositorioBase<Inscripciones> r = new RepositorioBase<Inscripciones>();
            bool paso = false;
            paso = r.Guardar(inscripcion);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void InscripcionModificarTest()
        {
            RepositorioBase<Inscripciones> repositorio = new RepositorioBase<Inscripciones>();
            bool paso = false;
            Inscripciones inscripcion = repositorio.Buscar(1);
            inscripcion.MontoCreditos = 500;
            paso = repositorio.Modificar(inscripcion);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void InscripcionBuscarTest()
        {
            RepositorioBase<Inscripciones> repositoriobase = new RepositorioBase<Inscripciones>();
            Inscripciones inscripcion = repositoriobase.Buscar(1);
            Assert.IsNotNull(inscripcion);
        }

        [TestMethod()]
        public void InscripcionGetListTest()
        {
            RepositorioBase<Inscripciones> repositorio = new RepositorioBase<Inscripciones>();
            List<Inscripciones> lista = new List<Inscripciones>();
            lista = repositorio.GetList(e => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void InscripcionEliminarTest()
        {
            RepositorioBase<Inscripciones> repositoriobase = new RepositorioBase<Inscripciones>();
            bool paso = false;
            paso = repositoriobase.Eliminar(1);
            Assert.AreEqual(true, paso);
        }
    }
}

