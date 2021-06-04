using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCuenta.Entidades.Entidades
{
    [DataContract]
    public class Cuenta
    {
        [DataMember(Name = "nroCuenta")]
        public int NroCuenta { get; set; }

        [DataMember(Name = "descripcion")]
        public string Descripcion { get; set; }

        [DataMember(Name = "saldo")]
        public float Saldo { get; set; }

        [DataMember(Name = "fechaApertura")]
        public DateTime FechaApertura { get; set; }

        [DataMember(Name = "fechaModificación")]
        public DateTime FechaModificacion { get; set; }

        [DataMember(Name = "activo")]
        public bool Activo { get; set; }

        [DataMember(Name = "idCliente")]
        public int IdCliente { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }   


        public Cuenta() { }

        public Cuenta(string descripcion, float saldo, bool activo, int idCliente)
        {
            NroCuenta = 0;
            Descripcion = descripcion;
            Saldo = saldo;
            FechaApertura = DateTime.Today;
            FechaModificacion = DateTime.Now;
            Activo = activo;
            IdCliente = idCliente;
            Id = 0;
        }
    }
}
