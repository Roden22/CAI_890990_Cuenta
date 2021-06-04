using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Configuration;

namespace ProyectoCuenta.Entidades
{
    [DataContract]
    public class Cliente
    {
        // PROPIEDADES
        [DataMember(Name = "DNI")]
        public int Dni { get; set; }

        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        [DataMember(Name = "apellido")]
        public string Apellido { get; set; }

        [DataMember(Name = "fechaNacimiento")]
        public DateTime FechaNac { get; set; }

        [DataMember(Name = "direccion")]
        public string Direccion { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "telefono")]
        public string Telefono { get; set; }

        [DataMember(Name = "fechaAlta")]
        public DateTime FechaAlta { get; set; }

        [DataMember(Name = "activo")]
        public bool Activo { get; set; }

        [DataMember(Name = "usuario")]
        public string Usuario { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        // MÉTODOS
        public Cliente()
        {
            Inicializar(0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, DateTime.Today, true, 0);
        }
        public Cliente(int dni, string nombre, string apellido, string direccion, string email, string telefono, DateTime fechaNac, bool activo, int id = 0)
        {
            Inicializar(dni, nombre, apellido, direccion, email, telefono, fechaNac, activo, id);
        }

        private void Inicializar(int dni, string nombre, string apellido, string direccion, string email, string telefono, DateTime fechaNac, bool activo, int id = 0)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            FechaNac = fechaNac;
            FechaAlta = DateTime.Now;
            Activo = activo;
            Usuario = ConfigurationManager.AppSettings["REGISTRO"];
            Id = id;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido} - {Dni}";
        }
    }
}
