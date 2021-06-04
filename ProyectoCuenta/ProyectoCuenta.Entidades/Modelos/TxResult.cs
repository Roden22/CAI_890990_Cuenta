using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCuenta.Entidades.Modelos
{
    [DataContract]
    public class TxResult
    {
        [DataMember(Name = "isOk")]
        public bool IsOk { get; set; }

        [DataMember(Name = "error")]
        public string Error { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}



