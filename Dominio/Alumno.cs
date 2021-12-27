using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace socrateWSSOAP.Dominio
{
    [DataContract]
    public class Alumno
    {
        [DataMember]
        public string Codigoalumno { get; set; }

        [DataMember]
        public string Nombrealumno { get; set; }

        [DataMember]
        public string Apellidoalumno { get; set; }

        [DataMember]
        public string Dnialumno { get; set; }

        [DataMember]
        public string Correoalumno { get; set; }
    }
}