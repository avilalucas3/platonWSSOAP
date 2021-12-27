using socrateWSSOAP.Dominio;
using socrateWSSOAP.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace socrateWSSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISocratesService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISocratesService
    {
        [FaultContract(typeof(ErroresException))]

        [OperationContract]
        Alumno CrearAlumno(Alumno alumnoaCrear);

        [OperationContract]
        Alumno ObtenerAlumno(string codigo);

        [OperationContract]
        Alumno ModificarAlumno(Alumno alumnoaModificar);

        [OperationContract]
        void EliminarAlumno(string codigo);

        [OperationContract]
        List<Alumno> ListarAlumnos();

        [OperationContract]
        Docente CrearDocente(Docente docenteaCrear);

        [OperationContract]
        Docente ObtenerDocente(int codigo);

        [OperationContract]
        Docente ModificarDocente(Docente docenteaModificar);

        [OperationContract]
        void EliminarDocente(int codigo);

        [OperationContract]
        List<Docente> ListarDocentes();
    }
}
