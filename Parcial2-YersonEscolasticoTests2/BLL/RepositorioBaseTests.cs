using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tarea6.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parcial2_YersonEscolastico.Entidades;

namespace Tarea6.BLL.Tests
{

    /// <summary>
    /// Tests de Estudiantes
    /// </summary>
    /// 

    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void GuardarEstudianteTest()
        {
            Estudiantes entity = new Estudiantes()
            {
                EstudianteId = 0,
                FechaIngreso = DateTime.Now,
                Balance = 0,
                Nombre = "Carlos"
            };

            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();

            Assert.IsTrue(db.Guardar(entity));
        }

        [TestMethod()]
        public void ModificarEstudianteTest()
        {

            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();

            Estudiantes entity = new Estudiantes()
            {
                EstudianteId = 2,
                FechaIngreso = DateTime.Now,
                Balance = 100,
                Nombre = "Juan"
            };

            Assert.IsTrue(db.Modificar(entity));
        }


        [TestMethod()]
        public void BuscarEstudianteTest()
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();

            Assert.IsNotNull(db.Buscar(2));
        }


        [TestMethod()]
        public void GetListEstudiantesTest()
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();

            Assert.IsNotNull(db.GetList(E => true));
        }


        [TestMethod()]
        public void EliminarEstudiantesTest()
        {
            RepositorioBase<Estudiantes> db = new RepositorioBase<Estudiantes>();

            Assert.IsNotNull(db.Eliminar(3));
        }



        /// <summary>
        /// Tests de Asignaturas
        /// </summary>
        [TestMethod()]
        public void GuardarAsignaturaTest()
        {
            Asignaturas entity = new Asignaturas()
            {
                AsignaturaId = 0,
                Creditos = 0,
                Descripcion = "Matematica"
            };

            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();

            Assert.IsTrue(db.Guardar(entity));
        }


        [TestMethod()]
        public void ModificarAsignaturasTest()
        {

            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();

            Asignaturas entity = new Asignaturas()
            {
                AsignaturaId = 1,
                Creditos = 0,
                Descripcion = "Lengua Esp"
            };

            Assert.IsTrue(db.Modificar(entity));
        }


        [TestMethod()]
        public void BuscarAsignaturaTest()
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();

            Assert.IsNotNull(db.Buscar(1));
        }


        [TestMethod()]
        public void GetListAsignaturaTest()
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();

            Assert.IsNotNull(db.GetList(E => true));
        }


        [TestMethod()]
        public void EliminarAsignaturasTest()
        {
            RepositorioBase<Asignaturas> db = new RepositorioBase<Asignaturas>();

            Assert.IsNotNull(db.Eliminar(1));
        }

    }
}