using socrateWSSOAP.Dominio;
using socrateWSSOAP.Errores;
using socrateWSSOAP.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace socrateWSSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SocratesService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SocratesService.svc o SocratesService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SocratesService : ISocratesService
    {
        private AlumnoDAO alumnoDAO = new AlumnoDAO();
        private DocenteDAO docenteDAO = new DocenteDAO();
        public Alumno CrearAlumno(Alumno alumnoaCrear)
        {
            if(alumnoDAO.Obtener(alumnoaCrear.Codigoalumno) != null) //ya existe
            {
                throw new FaultException<ErroresException>(
                    new ErroresException()
                    {
                        Codigo = "101",
                        Descripcion = "El alumno YA EXISTE"
                    },
                    new FaultReason("Error al intentar creación"));
            }
            return alumnoDAO.Crear(alumnoaCrear);  
        }

        public Docente CrearDocente(Docente docenteaCrear)
        {
            if (docenteDAO.Obtener(docenteaCrear.Codigodocente) != null) //ya existe
            {
                throw new FaultException<ErroresException>(
                    new ErroresException()
                    {
                        Codigo = "101",
                        Descripcion = "El docente YA EXISTE"
                    },
                    new FaultReason("Error al intentar creación"));
            }
            return docenteDAO.Crear(docenteaCrear);
        }

        public void EliminarAlumno(string codigo)
        {
            alumnoDAO.Eliminar(codigo);
        }

        public void EliminarDocente(int codigo)
        {
            docenteDAO.Eliminar(codigo);
        }

        public List<Alumno> ListarAlumnos()
        {
            return alumnoDAO.Listar();
        }

        public List<Docente> ListarDocentes()
        {
            return docenteDAO.Listar();
        }

        public Alumno ModificarAlumno(Alumno alumnoaModificar)
        {
            return alumnoDAO.Modificar(alumnoaModificar);
        }

        public Docente ModificarDocente(Docente docenteaModificar)
        {
            return docenteDAO.Modificar(docenteaModificar);
        }

        public Alumno ObtenerAlumno(string codigo)
        {
            return alumnoDAO.Obtener(codigo);
        }

        public Docente ObtenerDocente(int codigo)
        {
            return docenteDAO.Obtener(codigo);
        }

    }
}
