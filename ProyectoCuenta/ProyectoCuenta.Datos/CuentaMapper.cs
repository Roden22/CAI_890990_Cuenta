using Newtonsoft.Json;
using ProyectoCuenta.Entidades.Entidades;
using ProyectoCuenta.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCuenta.Datos
{
    public class CuentaMapper
    {
        public Cuenta Traer(int idCliente)
        {
            string jsonCuenta = WebHelper.Get("cuenta/" + idCliente);
            Cuenta cuenta = Map(jsonCuenta);

            return cuenta;
        }

        public TxResult CrearOModificar(Cuenta cuenta)
        {
            NameValueCollection nv = UnMap(cuenta);
            string jsonResponse = WebHelper.Post("cuenta", nv);
            TxResult response = JsonConvert.DeserializeObject<TxResult>(jsonResponse);

            return response;
        }

        private Cuenta Map(string json)
        {
            Cuenta cuenta = JsonConvert.DeserializeObject<Cuenta>(json);
            return cuenta;
        }

        private NameValueCollection UnMap(Cuenta cuenta)
        {
            NameValueCollection nv = new NameValueCollection();
            nv.Add("nroCuenta", cuenta.NroCuenta.ToString());
            nv.Add("descripcion", cuenta.Descripcion);
            nv.Add("saldo", cuenta.Saldo.ToString());
            nv.Add("fechaApertura", cuenta.FechaApertura.ToString());
            nv.Add("fechaModificacion", cuenta.FechaModificacion.ToString());
            nv.Add("activo", cuenta.Activo ? "true" : "false");
            nv.Add("idCliente", cuenta.IdCliente.ToString());
            nv.Add("id", cuenta.Id.ToString());

            return nv;
        }

    }
}
