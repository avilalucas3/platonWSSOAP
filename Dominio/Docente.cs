using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace socrateWSSOAP.Dominio
{
    [DataContract]
    public class Docente
    {
        [DataMember]
        public int Codigodocente { get; set; }

        [DataMember]
        public string Nombredocente { get; set; }

        [DataMember]
        public string Apellidodocente { get; set; }

        [DataMember]
        public string Dnidocente { get; set; }

        [DataMember]
        public string Correodocente { get; set; }
    }
}