using ProyectoCuenta.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoCuenta.Entidades.Modelos;
using System.Configuration;

namespace ProyectoCuenta.Datos
{
    public class ClienteMapper
    {
        public List<Cliente> TraerTodos()
        {
            //El get devuelve un json y el Map lo convierte en lista de clientes.
            string jsonClientes = WebHelper.Get("cliente" + "/" + ConfigurationManager.AppSettings["REGISTRO"]);
            List<Cliente> clientes = Map(jsonClientes);
            return clientes;
        }

        public TxResult Agregar(Cliente cliente)
        {
            NameValueCollection nv = UnMap(cliente);
            string jsonResponse = WebHelper.Post("cliente", nv);
            TxResult response = JsonConvert.DeserializeObject<TxResult>(jsonResponse);

            return response;
        }

        public TxResult Editar(Cliente cliente)
        {
            NameValueCollection nv = UnMap(cliente);
            string jsonResponse = WebHelper.Put("cliente", nv);
            TxResult response = JsonConvert.DeserializeObject<TxResult>(jsonResponse);

            return response;
        }

        public TxResult Eliminar(Cliente cliente)
        {
            NameValueCollection nv = UnMap(cliente);
            string jsonResponse = WebHelper.Delete("cliente", nv);
            TxResult response = JsonConvert.DeserializeObject<TxResult>(jsonResponse);

            return response;
        }

        private List<Cliente> Map(string json)
        {
            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return clientes;
        }

        private NameValueCollection UnMap(Cliente cliente)
        {
            NameValueCollection nv = new NameValueCollection();
            nv.Add("nombre", cliente.Nombre);
            nv.Add("apellido", cliente.Apellido);
            nv.Add("DNI", cliente.Dni.ToString());
            nv.Add("direccion", cliente.Direccion);
            nv.Add("email", cliente.Email);
            nv.Add("telefono", cliente.Telefono);
            nv.Add("activo", cliente.Activo ? "true":"false");
            nv.Add("fechaNacimiento", cliente.FechaNac.ToString());
            nv.Add("usuario", cliente.Usuario);
            nv.Add("id", cliente.Id.ToString());

            return nv;
        }
    }
}
